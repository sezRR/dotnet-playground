import ExtendedBreadcrumbList from "@/components/extended-breadcrumb-list";
import { TextareaForm } from "@/components/extended-text-area";
import { Separator } from "@/components/ui/separator";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import Message, { MessageVariant } from "@/components/message";
import { ScrollArea } from "@/components/ui/scroll-area";

export default function ChatPage() {
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
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message variant={MessageVariant.Sent} message="Hello, World!" />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
              <Message
                variant={MessageVariant.Received}
                message="Hello, World!"
              />
            </section>
          </ScrollArea>
          <TextareaForm />
        </div>
      </div>
    </div>
  );
}
