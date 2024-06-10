"use client";

import {
  DashboardSidebar,
  DashboardSidebarMain,
  DashboardSidebarNav,
  DashboardSidebarNavMain,
  DashboardSidebarNavLink,
  DashboardSidebarNavHeader,
  DashboardSidebarHeaderTitle,
  DashboardSidebarFooter,
  DashboardSidebarNavHeaderTitle,
} from "@/components/dashboard/sidebar";
import { usePathname } from "next/navigation";
import { EnvelopeOpenIcon, StarIcon } from "@radix-ui/react-icons";
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
          <DashboardSidebarNavHeader>
            <DashboardSidebarHeaderTitle className="text-lg my-8 hidden sm:block">
              Conexão do bem
            </DashboardSidebarHeaderTitle>
          </DashboardSidebarNavHeader>
          <DashboardSidebarNavMain>
            <DashboardSidebarNavLink
              href="/app/doadores"
              active={isActive("/app/doadores")}
            >
              <StarIcon className="w-4 h-4 mr-3" />
              <p className="hidden sm:block">Doadores</p>
            </DashboardSidebarNavLink>
            <DashboardSidebarNavLink
              href="/app/donatarios"
              active={isActive("/app/donatarios")}
            >
              <EnvelopeOpenIcon className="w-4 h-4 mr-3" />
              <p className="hidden sm:block">Donatários</p>
            </DashboardSidebarNavLink>
          </DashboardSidebarNavMain>
        </DashboardSidebarNav>
        <DashboardSidebarNav className="mt-auto">
          <DashboardSidebarNavHeader>
            <DashboardSidebarNavHeaderTitle>
              Usuarios
            </DashboardSidebarNavHeaderTitle>
          </DashboardSidebarNavHeader>
          <DashboardSidebarNavMain>
            <DashboardSidebarNavLink
              href="/app/usuario"
              active={isActive("/app/usuario")}
            >
              Editar usuários
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
