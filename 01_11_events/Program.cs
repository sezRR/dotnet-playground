// MyEventPublisher myEventPublisher = new();
// MyEventPublisher.XHandler xDelegate = X;
// myEventPublisher.MyEvent += X;
// myEventPublisher.RaiseEvent();

MyEventPublisher myEventPublisher2 = new();
myEventPublisher2.MyEvent2 += X;
myEventPublisher2.RaiseEvent2();

void X()
{
    Console.WriteLine("EVENT");
}

class MyEventPublisher
{
    public delegate void XHandler();

    private XHandler xDelegate;
    public event XHandler MyEvent;
    
    public event XHandler MyEvent2
    {
        add
        {
            Console.WriteLine("Event added");
            xDelegate += value;
        }
        remove
        {
            Console.WriteLine("Event removed");
            xDelegate -= value;
        }
    }
    
    public void RaiseEvent()
    {
        MyEvent();
    }
    
    public void RaiseEvent2()
    {
        // MyEvent();
        xDelegate();
    }
}