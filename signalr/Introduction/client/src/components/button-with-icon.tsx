import { Button } from "./ui/button";

type Props = {
  icon: React.ReactNode;
  children: React.ReactNode;
} & React.ButtonHTMLAttributes<HTMLButtonElement>;

export default function ButtonWithIcon({ icon, children, ...props }: Props) {
  return (
    <Button {...props}>
      <span className="text-sm mr-2">{icon}</span>
      {children}
    </Button>
  );
}
