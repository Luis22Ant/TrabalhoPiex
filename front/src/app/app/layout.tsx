import { PropsWithChildren } from "react";
import { MainSidebar } from "./_components/main-sidebar";

const mockedUser = {
  name: "Matheus",
  email: "J5lTq@example.com",
  image: "https://github.com/matheusfarias.png",
  emailVerified: new Date(),
};

export default function Layout({ children }: PropsWithChildren) {
  return (
    <div className="flex gap-4 w-full">
      <MainSidebar user={mockedUser} />
      <main className="w-full">{children}</main>
    </div>
  );
}
