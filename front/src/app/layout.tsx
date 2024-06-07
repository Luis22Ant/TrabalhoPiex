import "./globals.css";
import { Toaster } from "@/components/ui/toaster";

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className="h-screen flex">
        {children}
        <Toaster />
      </body>
    </html>
  );
}
