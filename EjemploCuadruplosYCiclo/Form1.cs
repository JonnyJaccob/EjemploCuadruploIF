using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploCuadruplosYCiclo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		string[][] matrizTokens;
		private void btnInsertar_Click(object sender, EventArgs e)
		{
			if(!String.IsNullOrWhiteSpace(rchCodigoEjemplo.Text))
			{
				rchCodigoCargado.Text = "";
				matrizTokens = Reconocimiento(rchCodigoEjemplo.Text);//Acondicionamiento
				matrizTokens = FormatoPosfijo(matrizTokens);//Conversion Posfija
				rchCodigoCargado.Text = ConvertirArregloACadena(matrizTokens);
				//Conversion a cuadruplos
				Cuadruplos(matrizTokens, dtgViewCuadruplo);
			}
		}
		private string[][] Reconocimiento(string texto)
		{
			// Separar las líneas usando saltos de línea
			string[] lines = texto.Split('\n');

			// Crear el arreglo bidimensional
			string[][] result = new string[lines.Length][];

			for (int i = 0; i < lines.Length; i++)
			{
				// Separar los valores de cada línea usando espacios
				string[] values = lines[i].Split(' ');

				// Asignar los valores al arreglo bidimensional
				result[i] = values;
			}
			result = LimpiarArreglo(result);
			int inis = 0;
			int fiin = 0;
			bool ModoSE = false;
			for (int i = 0; i < result.GetLength(0); i++)
			{
				if(result[i][0] != null )
				{
					for (int j = 0; j < result[i].Length; j++)
					{
						if(result[i][j] =="PR21")//SEE
						{
							Array.Resize(ref result[i-1], result[i-1].Length + 1);
							// Agregar un nuevo arreglo de strings en la última posición
							result[i-1][result[i-1].Length - 1] = "SEE" ;
							ModoSE = true;
						}
						if(result[i][j] =="INIS" && ModoSE)
						{
							inis++;
						}
						if (result[i][j] == "FIIN" && ModoSE)
						{
							fiin++;
							if(inis >= fiin)
							{
								inis--;
								fiin--;
							}
							if(inis==0 && fiin == 0 && !Contiene(result[i+1],"PR01"))//SEF
							{
								ModoSE = false;
								if(result[i][result[i].Length-1] =="")
								{
									result[i][result[i].Length - 1] = "SEF";
								}
								else
								// Verificar si el tamaño de la matriz necesita ser redimensionado
								if (result[i] == null)
								{
									result[i] = new string[1]; // Crear un nuevo arreglo de tamaño 1
									result[i][0] = "SEF"; // Asignar el valor "SEF" al primer elemento del arreglo
								}
								else
								{
									Array.Resize(ref result[i], result[i].Length + 1); // Redimensionar el arreglo para agregar un nuevo elemento
									result[i][result[i].Length - 1] = "SEF"; // Asignar el valor "SEF" al último elemento del arreglo
								}

							}
						}
					}
				}
			}
			//Asignarle los POSTE Y POSTF para el formato posfijo
			for (int i = 0; i < result.GetLength(0); i++)
			{
				if (Contiene(result[i], "OPLA", "OPLN", "OPLO", "OPR1", "OPR2", "OPR3", "OPR4", "OPR5", "OPR6"))//LA LO LN > >= != == <= <else
				{
					int tamaño = result[i].Length;
					string[] nuevo = new string[tamaño + 2];
					int num = 0;
					for (int j = 0; j < tamaño; j++)
					{
						if(j == 0)
						{
							nuevo[num++] = result[i][j];
							nuevo[num++] = "POSTE";
						}else 
						if(j == tamaño-1)
						{
							nuevo[num++] = result[i][j];
							nuevo[num++] = "POSTF";
						}
						else
						{
							nuevo[num++] = result[i][j];
						}
					}
					result[i] = nuevo;
				}
				else
				if (result[i][0] != null)
				{
					for (int j = 0; j < result[i].Length; j++)
					{
						string palabra = result[i][j];
						//IsEnt
						if (result[i].Length >= 2 && palabra == "PR04")
						{
							result[i] = ReemplazarElementos(result[i], "ENTE", "ENTF");
							result[i] = DelimitarPosfijo(result[i]);
						}
						//IsREA
						if (result[i].Length >= 2 && palabra == "PR18")
						{
							result[i] = ReemplazarElementos(result[i], "REAE", "REAF");
							result[i] = DelimitarPosfijo(result[i]);
						}
						if (j > 2 && result[i][0] == "INIS"
								&& VerificarID(result[i][1])
								&& result[i][2] == "ASIG")
						{
							result[i] = ReemplazarElementos(result[i], "ASIGE", "ASIGF");
							result[i] = DelimitarPosfijo(result[i]);
						}
					}
				}
			}

			return result;
		}
		private static string[][] LimpiarArreglo(string[][] matriz)
		{
			List<string[]> nuevaMatriz = new List<string[]>();

			foreach (string[] fila in matriz)
			{
				// Filtrar los elementos no vacíos en la fila
				string[] filaFiltrada = fila.Where(elemento => !string.IsNullOrWhiteSpace(elemento)).ToArray();

				// Agregar la fila filtrada a la nueva matriz
				if (filaFiltrada.Length > 0)
				{
					nuevaMatriz.Add(filaFiltrada);
				}
			}

			return nuevaMatriz.ToArray();
		}
		private string[][] FormatoPosfijo(string[][] matriz)
		{
			for (int i = 0; i < matriz.Length; i++)
			{
				if (Contiene(matriz[i], "POSTE", "POSTF"))
				{
					string[] temporal = ObtenerElementosEntre(matriz[i], "POSTE", "POSTF");
					string temporal1 = ConversionPosfija(temporal);

					// Reemplazar los elementos reacomodados de vuelta en la matriz original
					string[] elementos = temporal1.Split(' ');
					elementos = LimpiarArreglo(elementos);

					//Esta manera borra los POSTE Y POSTF
					//// Buscar el índice de "POSTE" y "POSTF" en la matriz
					int indicePoste = Array.IndexOf(matriz[i], "POSTE");
					int indicePostf = Array.IndexOf(matriz[i], "POSTF");

					//string[] nuevaMatriz = new string[matriz[i].Length + elementos.Length - (indicePostf - indicePoste + 1)];

					//Array.Copy(matriz[i], 0, nuevaMatriz, 0, indicePoste);  // Copiar los elementos antes de "POSTE"
					//Array.Copy(elementos, 0, nuevaMatriz, indicePoste, elementos.Length);  // Copiar los elementos reacomodados
					//Array.Copy(matriz[i], indicePostf + 1, nuevaMatriz, indicePoste + elementos.Length, matriz[i].Length - indicePostf - 1);  // Copiar los elementos después de "POSTF"
					string[] nuevaMatriz = new string[matriz[i].Length + elementos.Length];

					Array.Copy(matriz[i], 0, nuevaMatriz, 0, indicePoste + 1);  // Copiar los elementos antes de "POSTE"
					Array.Copy(elementos, 0, nuevaMatriz, indicePoste + 1, elementos.Length);  // Copiar los elementos reacomodados
					Array.Copy(matriz[i], indicePostf, nuevaMatriz, indicePoste + elementos.Length + 1, matriz[i].Length - indicePostf);  // Copiar los elementos después de "POSTF"

					matriz[i] = nuevaMatriz;
				}
			}
			return matriz;
		}
		private static string ConvertirArregloACadena(string[][] arreglo)
		{
			List<string> elementos = new List<string>();

			foreach (string[] subarreglo in arreglo)
			{
				string subcadena = string.Join(" ", subarreglo);
				elementos.Add(subcadena);
			}

			string resultado = string.Join(Environment.NewLine, elementos);

			return resultado;
		}
		public static string[] LimpiarArreglo(string[] arreglo)
		{
			// Filtrar los elementos nulos o vacíos del arreglo
			string[] elementosFiltrados = arreglo.Where(elemento => !string.IsNullOrEmpty(elemento)).ToArray();

			return elementosFiltrados;
		}
		static bool VerificarID(string texto)
		{
			if (texto.Length >= 2)
			{
				string primerosDosCaracteres = texto.Substring(0, 2);
				return primerosDosCaracteres == "ID";
			}

			return false;
		}
		
		static string[] ReemplazarElementos(string[] arreglo, string primerString, string segundoString)
		{
			if (arreglo.Length < 2)
			{
				throw new ArgumentException("El arreglo debe tener al menos dos elementos.");
			}

			arreglo[0] = primerString;
			int indice = Array.IndexOf(arreglo, "FIIN");
			if (indice != -1)
			{
				arreglo[indice] = segundoString;
			}

			return arreglo;
		}
		private string[] DelimitarPosfijo(string[] arreglo)
		{
			string[] nuevoArreglo = new string[arreglo.Length * 2];
			int nuevoIndice = 0;
			bool mode = false;
			for (int i = 0; i < arreglo.Length; i++)
			{

				if (i >= 1 && (arreglo[i - 1] == "ENTE" || arreglo[i - 1] == "REAE")
					&& (arreglo[i] == "PR04" || arreglo[i] == "PR18"))
				{
					nuevoArreglo[nuevoIndice++] = arreglo[i];
					nuevoArreglo[nuevoIndice++] = "POSTE";
					mode = true;
				}
				else
				if (i >= 1 && arreglo[i - 1] == "ASIGE"
					&& arreglo[i].Substring(0, 2) == "ID")
				{
					nuevoArreglo[nuevoIndice++] = "POSTE";
					nuevoArreglo[nuevoIndice++] = arreglo[i];;
				}
				else if (i == arreglo.Length - 2 && mode)
				{
					nuevoArreglo[nuevoIndice++] = "POSTF";
					nuevoArreglo[nuevoIndice++] = arreglo[i];
					break;
				}
				else if (i == arreglo.Length - 1 && !mode)
				{
					nuevoArreglo[nuevoIndice++] = "POSTF";
					nuevoArreglo[nuevoIndice++] = arreglo[i];
					break;
				}
				else
				{
					nuevoArreglo[nuevoIndice++] = arreglo[i];
				}
			}


			Array.Resize(ref nuevoArreglo, nuevoIndice);
			return nuevoArreglo;
		}
		private bool Contiene(string[] arreglo, params string[] valores)
		{
			return arreglo.Intersect(valores).Any();
		}
		private string SepararExpresion(string expresion)
		{
			string[] arreglo = expresion.Split(' ');

			if (Contiene(arreglo, "OPLA", "OPLN", "OPLO", "OPR1", "OPR2", "OPR3", "OPR4", "OPR5", "OPR6"))
			{
				// Obtener el índice del primer elemento "PR21"
				int primerIndice = Array.IndexOf(arreglo, "PR21");

				// Obtener el índice del último elemento "POSTF"
				int ultimoIndice = Array.LastIndexOf(arreglo, "POSTF");

				if (primerIndice >= 0 && ultimoIndice >= 0)
				{
					// Eliminar el elemento "POSTF"
					arreglo = arreglo.Where(e => e != "POSTF").ToArray();

					// Insertar "POSTE" en la posición correcta
					List<string> listaExpresion = arreglo.ToList();
					listaExpresion.Insert(primerIndice, "POSTE");
					arreglo = listaExpresion.ToArray();

					// Unir los elementos del arreglo con espacios
					string nuevaExpresion = string.Join(" ", arreglo);

					return nuevaExpresion;
				}
			}

			return "POSTE " + expresion + " POSTF";
		}


		private string SepararExpresion(string expresion,int lugar)
		{
			string[] arreglo = expresion.Split(' ');

			if (Contiene(arreglo, "OPLA", "OPLN", "OPLO", "OPR1", "OPR2", "OPR3", "OPR4", "OPR5", "OPR6"))
			{
				int antepenultimoIndice = arreglo.Length - lugar;
				arreglo[antepenultimoIndice] = "POSTF";
				string nuevaExpresion = string.Join(" ", arreglo);

				return arreglo[0] + " POSTE " + nuevaExpresion;
			}
			else
			{
				return "POSTE " + expresion + " POSTF";
			}
		}

		private static string[] ObtenerElementosEntre(string[] arreglo,string izq,string der)
		{
			string inicio = izq;
			string fin = der;

			int indiceInicio = Array.IndexOf(arreglo, inicio);
			int indiceFin = Array.IndexOf(arreglo, fin);

			// Verificar si se encontraron ambos marcadores
			if (indiceInicio >= 0 && indiceFin >= 0 && indiceFin > indiceInicio)
			{
				// Extraer los elementos entre "POSTE" y "POSTF"
				int elementosCount = indiceFin - indiceInicio - 1;
				string[] elementos = new string[elementosCount];
				Array.Copy(arreglo, indiceInicio + 1, elementos, 0, elementosCount);

				return elementos;
			}

			// Si no se encontraron los marcadores, retornar un arreglo vacío o null, según convenga en tu caso
			return new string[0];
		}
		List<int> _CodigoAceptado = new List<int>();
		private void btnCargar_Click(object sender, EventArgs e)
		{
			dtgViewCuadruplo.Rows.Clear();
			dtgViewTablaSimbolo.Rows.Clear();

			dtgViewTablaSimbolo.Rows.Add("1", "_W","ENT","IDEN","_X","ID01","");
			dtgViewTablaSimbolo.Rows.Add("2", "_X", "ENT", "IDEN", "2", "ID02", "");
			dtgViewTablaSimbolo.Rows.Add("3", "_Y", "ENT", "IDEN", "( 2 + 3", "ID03", "");
			dtgViewTablaSimbolo.Rows.Add("4", "NULL", "ENT", "CONE", "2", "CNE01", "");
			dtgViewTablaSimbolo.Rows.Add("5", "NULL", "ENT", "CONE", "24", "CNE02", "");
			dtgViewTablaSimbolo.Rows.Add("6", "_Z", "ENT", "IDEN", "1", "ID04", "");

			string codigo = "ID01 ID02 ID03 OPSM CNE01 OPSM ID04 OPRS ASIG";
			rchCodigoCargado.Text = codigo;

			string[][] matrizCodigo = new string[][]
			{
				new string[] { "CXFA", "KLA", "_MAIN" },
				new string[] { "|" },
				new string[] { "_x", "2", "=" },
				new string[] { "_W", "_x", "_y", "+", "24", "+", "_z", "-", "="  },
				new string[] { "||" }
			};
			string[][] codigoPosFijo = new string[][]
			{
				new string[] { "CXFA", "KLA", "_MAIN" },
				new string[] { "|" },
				new string[] { "ID02", "CNE01","ASIG"},
				new string[] { "ID01", "ID02", "ID03", "OPSM", "CNE02","OPSM", "ID04", "OPRS", "ASIG" },
				new string[] { "||" }
			};

			_CodigoAceptado.Add(2);
			_CodigoAceptado.Add(3);

			if (_CodigoAceptado.Count > 0)
			{
				Cuadruplos(_CodigoAceptado, codigoPosFijo, dtgViewCuadruplo);
			}

		}
		private void Cuadruplos(List<int> _lista,string[][] matriz, DataGridView dtgTabla)
		{
			Stack<string> aux1 = new Stack<string>();
			Stack<string> aux2 = new Stack<string>();
			bool Finalizo = false;
			int ID = 0;
			for (int i = 0; i < matriz.Length; i++)
			{
				try
				{
					if (_lista.Contains(i))
					{
						for (int j = 0; j < matriz[i].Length; j++)
						{
							string y, x;
							string var = matriz[i][j];
							switch (TipoOperacion(matriz[i][j]))
							{
								case 2:
									break;
								case 1:
									if (aux1.Count >= 3)
									{
										string x1 = aux1.Pop();
										string y1 = aux1.Pop();
										aux2.Push(x1);
										y = aux2.Pop();
										aux2.Push(y1);
										x = aux2.Pop();
									}
									else
									{
										y = aux1.Pop();
										x = aux1.Pop();
									}
									ID++;
									string temporal = AsignarNumero(ID);
									if (j == matriz[i].Length - 2)
									{
										string primerElem;
										if (aux1.Count == 1)
										{
											primerElem = aux1.Pop();
											dtgTabla.Rows.Add("0", primerElem, x, y, var);
											Finalizo = true;
										}
										else
										{
											dtgTabla.Rows.Add("0", x, x, y, var);
											Finalizo = true;
										}
									}
									else
									{
										dtgTabla.Rows.Add("0", temporal, x, y, var);
										aux1.Push(temporal);
									}
									break;
								case 0 when Finalizo == false:
									y = aux1.Pop();
									x = aux1.Pop();
									dtgTabla.Rows.Add("0", x, y, "", var);
									break;
								default:
									aux1.Push(var);
									break;
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message);
				}
			}

			int TipoOperacion(string x )
			{
				if(EsIgual(x,"OPLA","OPLN","OPLO","OPR1","OPR2","OPR3","OPR4","OPR5","OPR6"))
				{
					return 2;
				}else if(EsIgual(x,"OPSM","OPRS","OPML","OPDV","OPEX"))
				{
					return 1;
				}else if(x == "ASIG")
				{
					return 0;
				}else
				{
					return -1;
				}
			}
			string AsignarNumero(int numero)
			{
				if (numero.ToString().Length == 1)
				{
					return "TE0" + numero;
				}
				else
				{
					return "TE" + numero;
				}
			}
		}
		private void Cuadruplos( string[][] matriz, DataGridView dtgTabla)
		{
			string[][] temporal1 = matriz
				.Select(innerArray => innerArray.Where(elemento => !string.IsNullOrEmpty(elemento)).ToArray())
				.Where(innerArray => innerArray.Length > 0)
				.ToArray();
			matriz = temporal1;
			Stack<string> aux1 = new Stack<string>();
			Stack<string> aux2 = new Stack<string>();
			Stack<string> _ModoRecorrido = new Stack<string>();
			int ID = 1;
			int Indice = 1;
			for (int i = 0; i < matriz.Length; i++)
			{
				for (int j = 0; j < matriz[i].Length; j++)
				{
					string y, x;
					string var = matriz[i][j];
					if(_ModoRecorrido.Count >0)
					{
						string modo = _ModoRecorrido.Peek();
						
						if (EsIgual(modo, "SEE"))
						{

						}
						
						
						if (EsIgual(modo, "ENTE", "REAE","ASIG") && !EsIgual(var,"PR04","PR18","ENTE","ENTF","REAE","REAF","POSTE","POSTF"))
						{
							if(EsIgual(var,"OPSM","OPRS","OPML","OPDV","OPEX","ASIG"))
							{
								if (aux1.Count >= 3)
								{
									string x1 = aux1.Pop();
									string y1 = aux1.Pop();
									aux2.Push(x1);
									y = aux2.Pop();
									aux2.Push(y1);
									x = aux2.Pop();
								}
								else
								{
									y = aux1.Pop();
									x = aux1.Pop();
								}
								
								if(var == "ASIG")
								{
									dtgTabla.Rows.Add(Indice++, x, y, "", var);
									aux1.Push(x);
								}
								else
								{
									//if(ContarElementosEntre(matriz[i],"POSTE","POSTF") >0){ }
									
									string temporal = AsignarNumero(ID++);
									dtgTabla.Rows.Add(Indice++, temporal, x, y, var);
									aux1.Push(temporal);
								}
							}else
							{
								aux1.Push(var);
							}
						}
					}
					//SE y Ali
					if (var == "PR21")
					{
						_ModoRecorrido.Push("SEE");
					}
					if (var == "SEF")
					{
						_ModoRecorrido.Pop();
					}
					//ENT
					if (var == "ENTE")
					{
						_ModoRecorrido.Push("ENTE");
					}
					if (var == "ENTF")
					{
						_ModoRecorrido.Pop();
					}
					//REA
					if (var == "REAE")
					{
						_ModoRecorrido.Push("REAE");
					}
					if (var == "REAF")
					{
						_ModoRecorrido.Pop();
					}
					//ASIG
					if (var == "ASIGE")
					{
						_ModoRecorrido.Push("ASIG");
					}
					if (var == "ASIGF")
					{
						_ModoRecorrido.Pop();
					}
				}
			}
			
			string AsignarNumero(int numero)
			{
				if (numero.ToString().Length == 1)
				{
					return "TE0" + numero;
				}
				else
				{
					return "TE" + numero;
				}
			}
		}
		private void btnSalir_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private bool EsIgual(string x, params string[] arreglo)
		{
			foreach (string y in arreglo)
			{
				if(x == y)
				{
					return true;
				}
			}
			return false;
		}
		static int ContarElementosEntre(string[] arreglo, string inicio, string fin)
		{
			string arregloString = string.Join(" ", arreglo);
			string[] arregloRecortado = arregloString.Split(new[] { inicio, fin }, StringSplitOptions.RemoveEmptyEntries);
			string resultado = arregloRecortado.Length > 1 ? arregloRecortado[1].Trim() : string.Empty;

			if (!string.IsNullOrEmpty(resultado))
			{
				string[] elementos = resultado.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				return elementos.Length;
			}

			return 0;
		}

		private string ConversionPosfija(string[] token)
		{
			string[] lista = token;
			Stack<string> pila = new Stack<string>();
			string salida = "";
			int inicios = 0;
			int cierres = 0;
			for (int i = 0; i <= lista.Length - 1; i++)
			{
				if (lista[i] == " ")
				{

				}
				else
				if (EsIgual(lista[i], "OPEX"))
				{
					pila.Push(lista[i]);


				}
				else
				if (EsIgual(lista[i], "OPEX", "OPML", "OPDV", "OPSM", "OPRS","ASIG", "OPLA", "OPLN", "OPLO", "OPR1", "OPR2", "OPR3", "OPR4", "OPR5", "OPR6") || lista[i] == "CEX(" || lista[i] == "CEX)")
				{
					//Si es parentesis P1
					if (EsIgual(lista[i], "CEX(","CEX)"))
					{
						if (lista[i] == "CEX(")
						{
							inicios++;
						}
						else
						{
							cierres++;
						}
						pila.Push(lista[i]);
						if (inicios > 0 && cierres > 0)
						{
							string p;
							while (pila.Peek() != "CEX(")
							{
								if (pila.Peek() == "CEX)")
								{
									p = pila.Pop();//Saca el )
								}
								else
								{
									p = pila.Pop(); // saca el elemento
									salida += p + " ";
								}

							}
							pila.Pop();//Saca el (

							inicios--; cierres--;
						}
					}
					else
					// si es mutiplicacion o division P3
					if (EsIgual(lista[i], "OPML", "OPDV"))
					{
						if (pila.Count > 0 && EsIgual(pila.Peek(), "OPEX", "OPML", "OPDV"))
						{
							salida += pila.Pop() + " ";
							pila.Push(lista[i]);
						}
						else
						{
							pila.Push(lista[i]);
						}
					}
					else
					//si es suma o resta P4
					if (EsIgual(lista[i], "OPSM", "OPRS"))
					{
						if (pila.Count > 0 && EsIgual(pila.Peek(), "OPEX", "OPML", "OPDV", "OPSM", "OPRS"))
						{
							salida += pila.Pop() + " ";
							pila.Push(lista[i]);
						}
						else
						{
							pila.Push(lista[i]);
						}
					}
					else
					//Si es op relacional 
					if(EsIgual(lista[i], "OPR1", "OPR2", "OPR3", "OPR4", "OPR5", "OPR6"))
					{
						if (pila.Count > 0 && EsIgual(pila.Peek(), "OPEX", "OPML", "OPDV", "OPSM", "OPRS", "OPR1", "OPR2", "OPR3", "OPR4", "OPR5", "OPR6"))
						{
							salida += pila.Pop() + " ";
							pila.Push(lista[i]);
						}
						else
						{
							pila.Push(lista[i]);
						}
					}
					else
					//si es op logica
					if (EsIgual(lista[i], "OPLA", "OPLN", "OPLO"))
					{
						if (pila.Count > 0 && EsIgual(pila.Peek(), "OPEX", "OPML", "OPDV", "OPSM", "OPRS", "OPR1", "OPR2", "OPR3", "OPR4", "OPR5", "OPR6", "OPLA", "OPLN", "OPLO"))
						{
							salida += pila.Pop() + " ";
							pila.Push(lista[i]);
						}
						else
						{
							pila.Push(lista[i]);
						}
					}
					else
					//si es suma o resta P5
					if (lista[i] == "ASIG")
					{
						if (pila.Count > 0 && EsIgual(pila.Peek(), "OPEX", "OPML", "OPDV", "OPSM", "OPRS"))
						{
							salida += pila.Pop() + " ";
							pila.Push(lista[i]);
						}
						else
						{
							pila.Push(lista[i]);
						}
					}
					else
					{
						//algo fuera de lo comun, no hacer nada
					}
				}
				else
				{
					string sinEspacios = "";
					foreach (char item in lista[i])
					{
						if (item != ' ')
						{
							sinEspacios += item;
						}
					}
					salida += sinEspacios + " ";
				}
				if (i == lista.Length - 1)
				{
					while (pila.Count > 0)
					{
						string x = pila.Pop();
						if (x == "CEX(" || x == "CEX)")
						{

						}
						else
						{
							salida += x + " ";
						}
					}

				}
			}
			return  salida;
		}

		private void btnLlenar_Click(object sender, EventArgs e)
		{
			rchCodigoEjemplo.Text = "PR26 PR10 ID01\nINIS\nINIS PR04 ID01 ASIG CNE04 FIIN \nPR21 CEX( ID01 OPR1 CNE01 CEX) OPLA CEX( ID01 OPR6 CNE02 CEX) \nINIS\nINIS ID01 ASIG ID01 OPSM CNE03 FIIN\nFIIN\nPR01\nINIS\nINIS ID01 ASIG CNE01 FIIN\nFIIN \nFIIN ";
		}
	}
}
