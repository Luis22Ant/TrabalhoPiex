"use client";

import {
  Card,
  CardHeader,
  CardTitle,
  CardDescription,
  CardContent,
} from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";
import Link from "next/link";
import { Button } from "@/components/ui/button";
import { useForm } from "react-hook-form";
import { toast } from "@/components/ui/use-toast";

export function AuthForm() {
  const { register, handleSubmit } = useForm();

  const onSubmit = (data: any) => {
    console.log(data);

    toast({
      title: "Ocorreu um erro",
      description: "Email ou senha inválidos.",
      variant: "destructive",
    });
  };

  return (
    <div className="flex h-screen w-full items-center justify-center bg-gray-100 dark:bg-gray-950">
      <Card className="w-full max-w-md">
        <CardHeader className="space-y-1">
          <CardTitle className="text-2xl font-bold">Login</CardTitle>
          <CardDescription>
            Digite seu email e sua senha para acessar sua onta
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
            <div className="space-y-2">
              <Label htmlFor="email">Email</Label>
              <Input
                id="email"
                type="email"
                placeholder="m@example.com"
                required
                {...register("email")}
              />
            </div>
            <div className="space-y-2">
              <div className="flex items-center justify-between">
                <Label htmlFor="password">Senha</Label>
                <Link
                  href="#"
                  className="text-sm font-medium text-gray-500 hover:underline dark:text-gray-400"
                  prefetch={false}
                >
                  Esqueceu sua senha?
                </Link>
              </div>
              <Input
                id="password"
                type="password"
                required
                {...register("password")}
              />
            </div>
            <Button type="submit" className="w-full">
              Login
            </Button>
          </form>
        </CardContent>
      </Card>
    </div>
  );
}
