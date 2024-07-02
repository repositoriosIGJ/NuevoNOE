using System;
using System.Collections.Generic;

namespace NUEVO.NOE.Model.Seguridad;

public partial class RolFuncion
{
    public int? Rolid { get; set; }

    public int? Funid { get; set; }

    public virtual Funcion? Fun { get; set; }

    public virtual Rol? Rol { get; set; }
}
