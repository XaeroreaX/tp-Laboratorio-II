# tp-Laboratorio-II
mis tps


PENDIENTE DEL TEMA BINARIO




+        public static string BinarioDecimal(string binario)
+        {
+            int numero = 0;
+            for (int x = binario.Length - 1, y = 0; x >= 0; x--, y++)
+            {
+                if (binario[x] == '0' || binario[x] == '1')
+                    numero += (int)(int.Parse(binario[x].ToString()) * Math.Pow(2, y));
+                else
+                    return "Valor invalido";
+            }
+            return Convert.ToString(numero);
+        }
+
+        public static string DecimalBinario(double numero)
+        {
+            string binario = "";
+            if (numero > 0)
+            {
+                while (numero > 0)
+                {
+                    if (numero % 2 == 0)
+                    {
+                        binario = "0" + binario;
+                    }
+                    else
+                    {
+                        binario = "1" + binario;
+                    }
+
+                    numero = (int)numero / 2;
+                }
+            }
+            else if (numero == 0)
+            {
+                binario = "0";
+            }
+            else
+            {
+                binario = "Valor invalido";
+            }
+
+            return binario;
+
+        }
