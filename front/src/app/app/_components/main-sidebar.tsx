"use client";

import {
  DashboardSidebar,
  DashboardSidebarMain,
  DashboardSidebarNav,
  DashboardSidebarNavMain,
  DashboardSidebarNavLink,
  DashboardSidebarNavHeader,
  DashboardSidebarNavHeaderTitle,
  DashboardSidebarFooter,
} from "@/components/dashboard/sidebar";
import { usePathname } from "next/navigation";
import { HomeIcon, MixerVerticalIcon } from "@radix-ui/react-icons";
import { UserDropdown } from "./user-dropdown";
import { Session } from "next-auth";

type MainSidebarProps = {
  user: Session["user"];
};

export function MainSidebar({ user }: MainSidebarProps) {
  const pathname = usePathname();

  const isActive = (path: string) => {
    return pathname === path;
  };

  return (
    <DashboardSidebar>
      <DashboardSidebarMain className="flex flex-col flex-grow pt-2">
        <DashboardSidebarNav>
          <DashboardSidebarNavMain>
            <DashboardSidebarNavLink href="/app" active={isActive("/app")}>
              <HomeIcon className="w-3 h-3 mr-3" />
              Tarefas
            </DashboardSidebarNavLink>
            <DashboardSidebarNavLink
              href="/app/settings"
              active={isActive("/app/settings")}
            >
              <MixerVerticalIcon className="w-3 h-3 mr-3" />
              Configurações
            </DashboardSidebarNavLink>
          </DashboardSidebarNavMain>
        </DashboardSidebarNav>
      </DashboardSidebarMain>
      <DashboardSidebarFooter>
        <UserDropdown user={user} />
      </DashboardSidebarFooter>
    </DashboardSidebar>
  );
}
