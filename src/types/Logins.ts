import { z } from "zod";
export interface LoginCreate{
    Email: string;
    password: string;
}
export const LoginSchema = z.object({
    Email: z.string().email(),
    password: z.string().min(8,{message:"La contraseña debe tener al menos 8 caracteres"})
})
