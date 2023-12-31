﻿using Entities.Entities.Enums;
using Entities.Notifications;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_COMPRA_USUARIO")]
    public class CompraUsuario : Notifiers
    {
        [Column("CUS_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("TB_PRODUTO")]
        [Column(Order = 1)]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 2)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Column("CUS_ESTADO")]
        [Display(Name = "Estado")]
        public EEstadoCompra Estado { get; set; }

        [Column("CSU_QTD")]
        [Display(Name = "Quantidade")]
        public int QtdCompra { get; set; }

    }
}
