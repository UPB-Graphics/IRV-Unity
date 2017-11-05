using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class UserResources
{
	public static int coins { get; private set; }

	public delegate void CoinCollected();
	public static event CoinCollected OnChange;

	public UserResources()
	{ }

	public static void CollectCoin()
	{
		coins++;
		if (OnChange != null)
		{
			OnChange();
		}
	}

}

