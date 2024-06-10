"use client";

import { Button } from "@/components/ui/button";
import {
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Dialog } from "@radix-ui/react-dialog";
import { Pencil1Icon, TrashIcon } from "@radix-ui/react-icons";
import { useState } from "react";
import { useForm } from "react-hook-form";

const users = [
  {
    name: "John Doe",
    cpf: "123.456.789-00",
    date: "2023-05-01",
  },
  {
    name: "Jane Smith",
    cpf: "987.654.321-00",
    date: "2023-04-15",
  },
];

export default function Usuarios() {
  const { register, handleSubmit } = useForm();
  const [filter, setFilter] = useState({ nameOrCpf: "", dateFrom: "" });

  const filteredUsers = users.filter(
    (user) =>
      (user.name.toLowerCase().includes(filter.nameOrCpf.toLowerCase()) ||
        user.cpf.toLowerCase().includes(filter.nameOrCpf.toLowerCase())) &&
      (filter.dateFrom
        ? new Date(user.date) >= new Date(filter.dateFrom)
        : true)
  );
  return (
    <div className="overflow-x-auto w-full">
      <h1 className="text-3xl p-8">Usuários</h1>
      <div className="overflow-x-auto">
        <div className="border rounded-lg w-full">
          <div className="relative w-full overflow-auto">
            <div className="p-4 flex items-center gap-4 justify-between">
              <Input
                type="text"
                placeholder="Pesquisar pelo nome ou cpf"
                value={filter.nameOrCpf}
                onChange={(e) =>
                  setFilter((prev) => ({ ...prev, nameOrCpf: e.target.value }))
                }
              />
              <Dialog>
                <DialogTrigger asChild>
                  <Button size="sm">Adicionar Usuário</Button>
                </DialogTrigger>
                <DialogContent>
                  <DialogHeader>
                    <DialogTitle>Cadastrar novo usuário</DialogTitle>
                  </DialogHeader>
                  <form
                    onSubmit={handleSubmit((data) => console.log(data))}
                    className="space-y-4 mx-8"
                  >
                    <div className="flex items-center  gap-3">
                      <Label className="w-16" htmlFor="nome">
                        Nome
                      </Label>
                      <Input id="nome" type="text" {...register("nome")} />
                    </div>
                    <div className="flex items-center  gap-3">
                      <Label className="w-16" htmlFor="email">
                        Email
                      </Label>
                      <Input id="email" type="text" {...register("email")} />
                    </div>
                    <div className="flex items-center  gap-3">
                      <Label className="w-16" htmlFor="senha">
                        Senha
                      </Label>
                      <Input id="senha" type="text" {...register("senha")} />
                    </div>

                    <Button type="submit">Cadastrar</Button>
                  </form>
                </DialogContent>
              </Dialog>
            </div>
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead>Nome</TableHead>
                  <TableHead>CPF</TableHead>
                  <TableHead>Data de Cadastro</TableHead>
                  <TableHead>Ações</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {filteredUsers.map((user) => (
                  <TableRow key={user.name}>
                    <TableCell>{user.name}</TableCell>
                    <TableCell>{user.cpf}</TableCell>
                    <TableCell>{user.date}</TableCell>
                    <TableCell>
                      <Button variant="outline" size="sm" className="mr-2">
                        <Pencil1Icon />
                      </Button>
                      <Button variant="destructive" size="sm">
                        <TrashIcon />
                      </Button>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </div>
        </div>
      </div>
    </div>
  );
}
