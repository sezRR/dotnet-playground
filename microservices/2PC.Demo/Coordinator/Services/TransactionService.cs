﻿using Coordinator.Models;
using Coordinator.Models.Contexts;
using Coordinator.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Coordinator.Services;

public class TransactionService(
    IHttpClientFactory _httpClientFactory, 
    TwoPhaseCommitDbContext _context) : ITransactionService // positional inject
{
    HttpClient _orderHttpClient = _httpClientFactory.CreateClient("OrderAPI");
    HttpClient _stockHttpClient = _httpClientFactory.CreateClient("StockAPI");
    HttpClient _paymentHttpClient = _httpClientFactory.CreateClient("PaymentAPI");

    public async Task<Guid> CreateTransactionAsync()
    {
        Guid transactionId = Guid.NewGuid();

        var nodes = await _context.Nodes.ToListAsync();
        nodes.ForEach(node => node.NodeStates = new List<NodeState>()
        {
            new(transactionId)
            {
                IsReady = Enums.ReadyType.Pending,
                TransactionState = Enums.TransactionState.Pending,
            }
        });

        await _context.SaveChangesAsync();

        return transactionId;
    }

    public async Task PrepareServicesAsync(Guid transactionId)
    {
        var transactionalNodes = await _context.NodeStates
            .Include(ns => ns.Node)
            .Where(ns => ns.TransactionId == transactionId)
            .ToListAsync();

        foreach (var transactionalNode in transactionalNodes)
        {
            try
            {
                var response = await (transactionalNode.Node.Name switch
                {
                    "Order.API" => _orderHttpClient.GetAsync("ready"),
                    "Stock.API" => _stockHttpClient.GetAsync("ready"),
                    "Payment.API" => _paymentHttpClient.GetAsync("ready"),
                    _ => throw new NotImplementedException(),
                });

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                transactionalNode.IsReady = result ? Enums.ReadyType.Ready : Enums.ReadyType.NotReady;
            }
            catch
            {
                transactionalNode.IsReady = Enums.ReadyType.NotReady;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckReadyServicesAsync(Guid transactionId) => (await _context.NodeStates
            .Where(ns => ns.TransactionId == transactionId)
            .ToListAsync()).TrueForAll(ns => ns.IsReady == Enums.ReadyType.Ready);

    public async Task CommitAsync(Guid transactionId)
    {
        var transactionNodes = await _context.NodeStates
            .Where(ns => ns.TransactionId == transactionId)
            .Include(ns => ns.Node)
            .ToListAsync();

        foreach (var transactionalNode in transactionNodes)
        {
            try
            {
                var response = await (transactionalNode.Node.Name switch
                {
                    "Order.API" => _orderHttpClient.GetAsync("commit"),
                    "Stock.API" => _stockHttpClient.GetAsync("commit"),
                    "Payment.API" => _paymentHttpClient.GetAsync("commit"),
                    _ => throw new NotImplementedException(),
                });

                var result = bool.Parse(await response.Content.ReadAsStringAsync());

                transactionalNode.TransactionState = result ? Enums.TransactionState.Done : Enums.TransactionState.Abort;
            }
            catch
            {
                transactionalNode.TransactionState = Enums.TransactionState.Abort;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckTransactionStateServicesAsync(Guid transactionId) => (await _context.NodeStates
        .Where(ns => ns.TransactionId == transactionId).ToListAsync()).TrueForAll(ns => ns.TransactionState == Enums.TransactionState.Done);

    public async Task RollbackAsync(Guid transactionId)
    {
        var transactionalNodes = await _context.NodeStates
            .Where(ns => ns.TransactionId == transactionId)
            .Include(ns => ns.Node)
            .ToListAsync();

        foreach (var transactionalNode in transactionalNodes)
        {
            try
            {
                if (transactionalNode.TransactionState == Enums.TransactionState.Done)
                    _ = await (transactionalNode.Node.Name switch
                    {
                        "Order.API" => _orderHttpClient.GetAsync("rollback"),
                        "Stock.API" => _stockHttpClient.GetAsync("rollback"),
                        "Payment.API" => _paymentHttpClient.GetAsync("rollback"),
                        _ => throw new NotImplementedException()
                    });

                transactionalNode.TransactionState = Enums.TransactionState.Abort;
            }
            catch
            {
                transactionalNode.TransactionState = Enums.TransactionState.Abort;
            }
        }

        await _context.SaveChangesAsync();
    }
}
