import ExtendedBreadcrumbList from "@/components/extended-breadcrumb-list";
import { TextareaForm } from "@/components/extended-text-area";
import Message, { MessageVariant } from "@/components/message";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { ScrollArea } from "@/components/ui/scroll-area";
import { useToast } from "@/components/ui/use-toast";
import MessageSchema from "@/lib/interfaces/message";
import { connection } from "@/lib/services/signalr-service";
import { writeErrorToast } from "@/lib/utils";
import { useEffect, useState } from "react";

export default function ChatPage() {
  const [messages, setMessages] = useState<MessageSchema[]>([]);
  const { toast } = useToast();

  useEffect(() => {
    connection
      .start()
      .then(() => {
        toast({
          title: "SUCCESS",
          description: "Connected to SignalR websocket!",
        });
      })
      .catch((err: { toString: () => any }) => writeErrorToast(err));
  }, []);

  useEffect(() => {
    connection.on("ReceiveMessage", (message: string) => {
      const data = JSON.parse(message);

      setMessages((currMessages) => [...currMessages, data]);
    });

    connection.onclose(() => {
      toast({
        title: "Connection Closed",
        description: "Connection successfully closed!",
      });
    });

    return () => {
      connection.off("ReceiveMessage");
    };
  }, [messages]);

  return (
    <div className="flex flex-grow justify-center">
      <div className="flex max-w-3xl flex-grow flex-col gap-5 rounded-2xl px-4 py-12">
        <div className="flex flex-row items-center justify-between">
          <header className="flex flex-row items-center gap-4">
            <Avatar className="ml-2 h-8 w-8">
              <AvatarImage src="https://github.com/shadcn.png" alt="@shadcn" />
              <AvatarFallback>CN</AvatarFallback>
            </Avatar>
            <span className="text-xl font-bold">shadcn</span>
          </header>
          <ExtendedBreadcrumbList />
        </div>
        <div className="flex h-screen flex-1 flex-col gap-5">
          <ScrollArea className="max-h-[58vh] flex-grow overflow-y-auto rounded-md border">
            <section className="flex flex-col gap-2 px-4 py-2.5">
              {messages.map((message) => (
                <Message
                  key={message.message}
                  message={message.message}
                  variant={MessageVariant.Received}
                />
              ))}
            </section>
          </ScrollArea>
          <TextareaForm />
        </div>
      </div>
    </div>
  );
}
