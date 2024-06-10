"use client";

import CustomDialog from "@/components/dashboard/CustomDialog";
import { Button } from "@/components/ui/button";
import { Dialog } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { DialogTrigger } from "@radix-ui/react-dialog";
import { Pencil1Icon, TrashIcon } from "@radix-ui/react-icons";
import { useState } from "react";

const donatarios = [
  {
    name: "John Doe",
    cpf: "123.456.789-00",
    date: "2023-05-01",
    items: "1x saco de arroz",
  },
  {
    name: "Jane Smith",
    cpf: "987.654.321-00",
    date: "2023-04-15",
    items: "2x sacos de leite",
  },
  {
    name: "Michael Johnson",
    cpf: "456.789.123-00",
    date: "2023-03-10",
    items: "3x latas de cerveja",
  },
];

export default function Doadores() {
  const [filter, setFilter] = useState({ nameOrCpf: "", dateFrom: "" });
  const filteredDonors = donatarios.filter(
    (donatario) =>
      (donatario.name.toLowerCase().includes(filter.nameOrCpf.toLowerCase()) ||
        donatario.cpf.toLowerCase().includes(filter.nameOrCpf.toLowerCase())) &&
      (filter.dateFrom
        ? new Date(donatario.date) >= new Date(filter.dateFrom)
        : true)
  );

  return (
    <div className="overflow-x-auto w-full">
      <h1 className="text-3xl p-8">Doadores</h1>
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
                  <Button size="sm">Adicionar Doador</Button>
                </DialogTrigger>
                <CustomDialog />
              </Dialog>
            </div>
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead>Nome</TableHead>
                  <TableHead>CPF</TableHead>
                  <TableHead>Data</TableHead>
                  <TableHead>Items Doados</TableHead>
                  <TableHead className="text-right">Ações</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {filteredDonors.map((donor) => (
                  <TableRow key={donor.name}>
                    <TableCell className="font-medium">{donor.name}</TableCell>
                    <TableCell>{donor.cpf}</TableCell>
                    <TableCell>{donor.date}</TableCell>
                    <TableCell>{donor.items}</TableCell>
                    <TableCell className="text-right">
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
