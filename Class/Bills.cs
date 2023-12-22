namespace Test.Class
{
	/// <summary>
	/// Clase que representa información sobre facturas y gastos.
	/// </summary>
	public class Bills
	{
		private string Cash;
		private string Card;

		/// <summary>
		/// Inicializa una nueva instancia de la clase Bills.
		/// </summary>
		public Bills()
		{
			Cash = "efectivo";
			Card = "tarjeta";
			_description = string.Empty;
			_category = string.Empty;
			_type = string.Empty;

			//Nota: Se inicializan los atributos string como emptys (vacios) para evitar advertencias.
		}

		/// <summary>
		/// Obtiene o establece la fecha asociada a la factura.
		/// </summary>
		private DateTime _date;

		/// <summary>
		/// Obtiene o establece la fecha asociada a la factura.
		/// </summary>
		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		/// <summary>
		/// Obtiene o establece la descripción de la factura.
		/// </summary>
		private string _description;

		/// <summary>
		/// Obtiene o establece la descripción de la factura.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Obtiene o establece la categoría de la factura.
		/// </summary>
		private string _category;

		/// <summary>
		/// Obtiene o establece la categoría de la factura.
		/// </summary>
		public string Category
		{
			get { return _category; }
			set { _category = value; }
		}

		/// <summary>
		/// Obtiene o establece el monto de la factura.
		/// </summary>
		private decimal _amount;

		/// <summary>
		/// Obtiene o establece el monto de la factura.
		/// </summary>
		public decimal Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		/// <summary>
		/// Obtiene o establece el tipo de pago de la factura (Efectivo o Tarjeta).
		/// </summary>
		private string _type;

		/// <summary>
		/// Obtiene o establece el tipo de pago de la factura (Efectivo o Tarjeta).
		/// </summary>
		public string Type
		{
			get { return _type; }
			set
			{
				if (value.ToLower() != Cash && value.ToLower() != Card)
				{
					throw new ArgumentException("Tipo de pago no válido. Los valores permitidos son 'Efectivo' o 'Tarjeta'.");
				}
				else
				{
					_type = value;
				}
			}
		}
	}
}
