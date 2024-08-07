import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormMessage,
} from "@/components/ui/form";
import { Textarea } from "@/components/ui/textarea";
import { toast } from "@/components/ui/use-toast";
import ButtonWithIcon from "./button-with-icon";
import { Send } from "lucide-react";
import { sendMessage } from "@/lib/services/signalr-service";
import MessageSchema from "@/lib/interfaces/message";

const FormSchema = z.object({
  message: z
    .string()
    .min(10, {
      message: "Your message must be at least 10 characters.",
    })
    .max(160, {
      message: "Your message must not be longer than 30 characters.",
    }),
});

export function TextareaForm() {
  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
  });

  async function onSubmit(data: z.infer<typeof FormSchema>) {
    toast({
      title: "You submitted the following values:",
      description: (
        <pre className="mt-2 w-[340px] rounded-md bg-slate-950 p-4">
          <code className="text-white">{JSON.stringify(data, null, 2)}</code>
        </pre>
      ),
    });

    const message: MessageSchema = {
      message: JSON.stringify(data, null, 2),
    };

    await sendMessage(message);

    toast({
      title: "Message Sent",
      description: "Your message sent successfully to SignalR websocket!",
    });
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="flex w-full flex-row items-start justify-around space-y-6"
      >
        <FormField
          control={form.control}
          name="message"
          render={({ field }) => (
            <FormItem className="mr-2 flex-grow">
              <FormControl>
                <Textarea
                  placeholder="Type your message here..."
                  className="w-fill min-h-[10vh] resize-none"
                  {...field}
                />
              </FormControl>
              <FormDescription>
                Tip: You can <span>@mention</span> other users and
                organizations.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <ButtonWithIcon icon={<Send size={18} strokeWidth={1.5} />}>
          Send
        </ButtonWithIcon>
      </form>
    </Form>
  );
}
