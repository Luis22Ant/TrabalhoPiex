import {
  DialogClose,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogTitle,
} from "../ui/dialog";
import { Label } from "../ui/label";
import { Input } from "../ui/input";
import { format } from "date-fns";
import { ptBR } from "date-fns/locale";
import { useForm } from "react-hook-form";
import { Button } from "../ui/button";

export default function CustomDialog({
  isDonation = false,
}: {
  isDonation?: boolean;
}) {
  const date = new Date();
  const formattedDate = format(date, "eeee, dd/MM/yyyy", { locale: ptBR });
  const { register, handleSubmit } = useForm();

  return (
    <DialogContent>
      <DialogHeader>
        <DialogTitle>
          {isDonation ? "Adicionar donatário" : "Adicionar doação"}
        </DialogTitle>
      </DialogHeader>
      <form
        onSubmit={handleSubmit((data) => console.log(data))}
        className="grid gap-4"
      >
        <div className="grid grid-cols-4 items-center text-right gap-3">
          <Label htmlFor="name">Nome</Label>
          <Input
            id="name"
            type="text"
            className="col-span-3"
            {...register("name")}
          />
        </div>
        <div className="grid grid-cols-4 items-center text-right gap-3">
          <Label htmlFor="cpf">CPF</Label>
          <Input
            id="cpf"
            type="text"
            className="col-span-3"
            {...register("cpf")}
          />
        </div>
        <div className="grid grid-cols-4 items-center text-right gap-3">
          <Label htmlFor="data">Data</Label>
          <Input
            id="data"
            type="text"
            className="col-span-3"
            value={formattedDate}
            {...register("date")}
          />
        </div>
        <div className="grid grid-cols-4 items-center text-right gap-3">
          <Label htmlFor="items">
            Items {isDonation ? "recebidos" : "doados"}
          </Label>
          <Input
            id="items"
            type="text"
            className="col-span-3"
            {...register("items")}
          />
        </div>
        <DialogFooter className="justify-end">
          <DialogClose>
            <Button variant="outline">Cancelar</Button>
          </DialogClose>
          <Button type="submit">Adicionar</Button>
        </DialogFooter>
      </form>
    </DialogContent>
  );
}
