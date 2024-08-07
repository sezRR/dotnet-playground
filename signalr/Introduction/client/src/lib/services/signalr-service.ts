import * as signalR from "@microsoft/signalr";
import MessageSchema from "../interfaces/message";
import { writeErrorToast } from "../utils";

export const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5253/hubs/myhub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    }) // URL of SignalR hub
    .withAutomaticReconnect()
    .build();

export const sendMessage = async ({ message }: MessageSchema) => {
    if (message)
        await connection.invoke("SendMessageAsync", message).catch((err: { toString: () => any; }) => writeErrorToast(err))
}
