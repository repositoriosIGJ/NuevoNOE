﻿using System;
using System.Collections.Generic;

namespace NUEVO.NOE.Model.Seguridad;

public partial class AreaDTO
{
    public int Id { get; set; }

    public string? Acronimo { get; set; }

    public string? Descripcion { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual DepartamentoDTO? Departamento { get; set; }
}
