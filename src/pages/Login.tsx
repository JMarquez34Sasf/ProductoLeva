import type { LoginCreate } from "../types/Logins";
import { useForm } from "react-hook-form"


function Login() {
    const {register, handleSubmit, formState: {errors}} = useForm<LoginCreate>();
  return (
    <div className="container">
        <div className="row">
            <div className="col-md-6">
                <form className="form-control" >
                    <label className="form-label">Usuario  </label>
                    <input className="form-control" type="text" {...register("Email")}></input>
                    {errors.Email?.message && <span className="text-danger small">{errors.Email.message.toString()}</span>}
                    <label className="form-label">Contraseña  </label>
                    <input className="form-control" type="password" {...register("password")}></input>
                    {errors.password?.message && <span className="text-danger small">{errors.password.message.toString()}</span>}
                    <button className="btn btn-primary " type="submit" >Iniciar sesión</button>
                </form>
            </div>
        </div>
    </div>

  )
}

export default Login