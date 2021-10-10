using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSuplemento.Matematicas
{
    class SimilaridadeCoseno
    {
        public double CompararVetores(double[] user1, double[] user2)
        {
            double somaProduto = 0.0;
            double somaQuadradoUm = 0.0;
            double somaQuadradoDois = 0.0;

            for (int i = 0; i < user1.Length; i++)
            {
                somaProduto += user1[i] * user2[i];
                somaQuadradoUm += Math.Pow(user1[i], 2);
                somaQuadradoDois += Math.Pow(user2[i], 2);
            }

            return somaProduto / (Math.Sqrt(somaQuadradoUm) * Math.Sqrt(somaQuadradoDois));
        }
    }
}
