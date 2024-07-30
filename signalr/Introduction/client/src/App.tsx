import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import "./App.css";
import { Toaster } from "./components/ui/toaster";
import ChatPage from "./pages/ChatPage";
import { ThemeProvider } from "./components/theme-provider";
import ChatLayout from "./layouts/ChatLayout";

function App() {
  return (
    <ThemeProvider defaultTheme="dark" storageKey="chat-client-ui-theme">
      <BrowserRouter>
        <Routes>
          <Route element={<ChatLayout />}>
            <Route index element={<Navigate replace to="chat" />} />
            <Route path="/chat" element={<ChatPage />} />
          </Route>
        </Routes>
        <Toaster />
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
