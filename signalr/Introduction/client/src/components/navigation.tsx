import { ThemeToggle } from "./theme-toggle";
import { TypographyH2 } from "./typography/typography-h2";

export default function Navigation() {
  return (
    <nav className="flex flex-row justify-between p-2">
      <TypographyH2>REACT + SIGNALR CHAT</TypographyH2>
      <ThemeToggle />
    </nav>
  );
}
