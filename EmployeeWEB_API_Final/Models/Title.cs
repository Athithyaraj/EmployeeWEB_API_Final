﻿using System;
using System.Collections.Generic;

namespace EmployeeWEB_API_Final.Models;

public partial class Title
{
    public int EmpNo { get; set; }

    public string Title1 { get; set; } = null!;

    public DateTime FromDate { get; set; }

    public virtual Employee EmpNoNavigation { get; set; } = null!;
}
