using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Enum.ServicesResult.Student
{
    public enum AddAsyncStatus
    {
        Exists,
        Ok,
        Bad
    }
    public enum DeleteAsyncStatus
    {
        NonExists,
        Ok,
        Bad
    }
}
