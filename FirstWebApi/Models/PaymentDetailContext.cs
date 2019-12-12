using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApi.Models
{
    /// <summary>
    /// Payment DbContext(using EF)
    /// </summary>
    public class PaymentDetailContext:DbContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options):base(options)
        {

        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

    }
}
