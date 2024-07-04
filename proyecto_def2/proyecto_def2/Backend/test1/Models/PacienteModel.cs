using ExpressionTree;
using DatabaseWrapper.Core;
using Watson.ORM;
using Watson.ORM.Core;

namespace test1.Models
{
    [Table("datos")]
    public class PacienteModel
    {
        [Column("id", true, DataTypes.Int, false)] //id en base de datos
        public int Id { get; set; }
        //datos paciente
        [Column("id_paciente", false, DataTypes.Nvarchar, 10, false)]
        public string? Id_paciente { get; set; }
        [Column("edad", false, DataTypes.Int, false)]
        public int? Edad { get; set; }
        [Column("sexo", false, DataTypes.Int, false)]
        public int? Sexo { get; set; }
        //signos vitales
        [Column("rpm", false, DataTypes.Int, false)]
        public int? Rpm { get; set; }
        [Column("pulse", false, DataTypes.Int, false)]
        public int? Pulse { get; set; }
        [Column("pres", false, DataTypes.Int, false)]
        public int? Pres { get; set; }

        [Column("temp",false ,DataTypes.Double, maxLength: 45 ,precision:3 ,false)]
        public double? Temp { get; set; }

        

    }
}
