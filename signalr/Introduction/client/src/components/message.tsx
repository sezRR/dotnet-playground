import { getHours } from "@/lib/utils";

type MessageProps = MessageVariantProps & {
  variant: MessageVariant;
};

type MessageVariantProps = {
  message: string;
};

export enum MessageVariant {
  Sent,
  Received,
}

function SentMessage({ message }: MessageVariantProps) {
  return (
    <div className="flex flex-col items-end gap-1">
      <div className="items-center rounded-3xl bg-secondary p-3">
        <p className="max-w-screen-sm break-words text-xs">{message}</p>
      </div>
      {GetMessageTime()}
    </div>
  );
}

function ReceivedMessage({ message }: MessageVariantProps) {
  return (
    <div className="flex flex-col items-start gap-1">
      <div className="items-center rounded-3xl bg-secondary p-3">
        <p className="max-w-screen-sm break-words text-xs">{message}</p>
      </div>
      {GetMessageTime()}
    </div>
  );
}

function GetMessageTime() {
  return (
    <span className="ml-2 text-xs text-accent-secondary">{getHours()}</span>
  );
}

export default function Message({ variant, message }: MessageProps) {
  switch (variant) {
    case MessageVariant.Sent:
      return <SentMessage message={message} />;
    case MessageVariant.Received:
      return <ReceivedMessage message={message} />;
    default:
      return null;
  }
}
