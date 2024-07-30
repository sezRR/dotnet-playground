import Navigation from "@/components/navigation";
import { Outlet } from "react-router-dom";

export default function ChatLayout() {
  return (
    <div className="flex min-h-screen flex-col px-12 py-8">
      <header>
        <Navigation />
      </header>
      <main className="flex flex-grow">
        <Outlet />
      </main>
    </div>
  );
}
