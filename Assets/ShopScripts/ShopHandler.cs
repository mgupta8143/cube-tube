using UnityEngine;
using UnityEngine.UI;
public class ShopHandler : MonoBehaviour
{
    // Start is called before the first frame updat  

    //to add button, make public put it in, go to start, onenable, edit button color, change button names thats it, copy and paste list
    private Text coinCount;
    public Button RedButton, BlueButton, GreenButton, YellowButton, PinkButton, PurpleButton, OrangeButton, GoldButton, WhiteButton;
    public Button CubeButton, SphereButton, BirdButton, TurtleButton, PlaneButton, XButton, HeadButton, BatmanButton;
    public Button RedPathColor, WhitePathColor, BluePathColor, YellowPathColor, OrangePathColor, GreenPathColor, PurplePathColor, PinkPathColor;
    public Button WhiteBlackColor, BlackWhiteColor, BlueYellowColor, GreenRedColor, PinkPurpleColor, GreenGreenColor, YellowYellowColor, OrangeRedColor;
    public Button RedTrail, BlackTrail, BlueTrail, YellowTrail, OrangeTrail, GreenTrail, PurpleTrail, PinkTrail;
    public Button ColorsButton, ShapesButton, PathColorsButton, ThemesButton, MusicButton, MoneyButton;
    public Text PlayerColorText, PlayerShapeText, PathColorText, ThemeText, MusicText, MoneyText;
    public GameObject PlayerColorShop, PlayerShapeShop, PathColorShop, ThemeShop, TrailShop;
    public GameObject ValuablesShop;
    public AudioSource moneySound;
    public AudioClip moneys;
    Animator cannot;

    //x = buttterfly, head  = sword, batman = flappy bird
    void Start()
    {
        coinCount = GameObject.Find("Count").GetComponent<Text>();
        cannot = GameObject.Find("Warning").GetComponent<Animator>();

        //for default
        PlayerPrefs.GetInt("ThemeOnce", 0);
        PlayerPrefs.GetInt("PathColorOnce", 0);
        PlayerPrefs.GetInt("PlayerShapeOnce", 0);
        PlayerPrefs.GetInt("PlayerColorOnce", 0);
        PlayerPrefs.GetInt("TrailOnce", 0);

        //must come after
        turnOnPlayerColorShop();
    }



    void OnEnable()
    {
        RedButton.onClick.AddListener(delegate { BuyColorItem(300, "Red"); });//adds a listener for when you click the button
        BlueButton.onClick.AddListener(delegate { BuyColorItem(300, "Blue"); });
        YellowButton.onClick.AddListener(delegate { BuyColorItem(300, "Yellow"); });
        GreenButton.onClick.AddListener(delegate { BuyColorItem(300, "Green"); });
        PurpleButton.onClick.AddListener(delegate { BuyColorItem(300, "Purple"); });
        PinkButton.onClick.AddListener(delegate { BuyColorItem(300, "Pink"); });
        OrangeButton.onClick.AddListener(delegate { BuyColorItem(300, "Orange"); });
        GoldButton.onClick.AddListener(delegate { BuyColorItem(300, "Gold"); });
        WhiteButton.onClick.AddListener(delegate {BuyColorItem(0, "White");});

        CubeButton.onClick.AddListener(delegate { buyPlayerShapeItem(0, "Cube"); });
        TurtleButton.onClick.AddListener(delegate { buyPlayerShapeItem(1000, "Turtle"); });
        SphereButton.onClick.AddListener(delegate { buyPlayerShapeItem(500, "Sphere"); });
        BirdButton.onClick.AddListener(delegate { buyPlayerShapeItem(700, "Bird"); });
        PlaneButton.onClick.AddListener(delegate { buyPlayerShapeItem(1200, "Plane"); });
        XButton.onClick.AddListener(delegate { buyPlayerShapeItem(1600, "X"); });
        HeadButton.onClick.AddListener(delegate { buyPlayerShapeItem(2000, "Head"); });
        BatmanButton.onClick.AddListener(delegate { buyPlayerShapeItem(10000, "Batman"); });

        RedPathColor.onClick.AddListener(delegate { buyPathColorItem(0, "RedPath"); });//adds a listener for when you click the button
        BluePathColor.onClick.AddListener(delegate { buyPathColorItem(300, "BluePath"); });
        YellowPathColor.onClick.AddListener(delegate { buyPathColorItem(300, "YellowPath"); });
        GreenPathColor.onClick.AddListener(delegate { buyPathColorItem(300, "GreenPath"); });
        PurplePathColor.onClick.AddListener(delegate { buyPathColorItem(300, "PurplePath"); });
        PinkPathColor.onClick.AddListener(delegate { buyPathColorItem(300, "PinkPath"); });
        OrangePathColor.onClick.AddListener(delegate { buyPathColorItem(300, "OrangePath"); });
        WhitePathColor.onClick.AddListener(delegate { buyPathColorItem(300, "WhitePath"); });

        WhiteBlackColor.onClick.AddListener(delegate { buyThemeItem(0, "WhiteBlackColor"); });//adds a listener for when you click the button
        BlackWhiteColor.onClick.AddListener(delegate { buyThemeItem(400, "BlackWhiteColor"); });
        BlueYellowColor.onClick.AddListener(delegate { buyThemeItem(500, "BlueYellowColor"); });
        GreenRedColor.onClick.AddListener(delegate { buyThemeItem(1000, "GreenRedColor"); });
        PinkPurpleColor.onClick.AddListener(delegate { buyThemeItem(1100, "PinkPurpleColor"); });
        GreenGreenColor.onClick.AddListener(delegate { buyThemeItem(1400, "GreenGreenColor"); });
        YellowYellowColor.onClick.AddListener(delegate { buyThemeItem(700, "YellowYellowColor"); });
        OrangeRedColor.onClick.AddListener(delegate { buyThemeItem(500, "OrangeRedColor"); });

        RedTrail.onClick.AddListener(delegate { buyTrailItem(0, "RedTrail"); });//adds a listener for when you click the button
        BlueTrail.onClick.AddListener(delegate { buyTrailItem(300, "BlueTrail"); });
        YellowTrail.onClick.AddListener(delegate { buyTrailItem(300, "YellowTrail"); });
        GreenTrail.onClick.AddListener(delegate { buyTrailItem(300, "GreenTrail"); });
        PurpleTrail.onClick.AddListener(delegate { buyTrailItem(300, "PurpleTrail"); });
        PinkTrail.onClick.AddListener(delegate { buyTrailItem(300, "PinkTrail"); });
        OrangeTrail.onClick.AddListener(delegate { buyTrailItem(300, "OrangeTrail"); });
        BlackTrail.onClick.AddListener(delegate { buyTrailItem(300, "BlackTrail"); });




        //
        //  public Button WhiteBlackColor, BlackWhiteColor, BlueYellowColor, GreenRedColor, PinkPurpleColor, GreenGreenColor, YellowYellowColor, OrangeRedColor;


        //  public Button CubeButton, SphereButton, BirdButton, , PlaneButton, XButton, HeadButton, BatmanButton;

        ShapesButton.onClick.AddListener(delegate { turnOnPlayerShapeShop(); });
        ColorsButton.onClick.AddListener(delegate { turnOnPlayerColorShop(); });
        PathColorsButton.onClick.AddListener(delegate { turnOnPathColorShop(); });
        ThemesButton.onClick.AddListener(delegate { turnOnThemeShop(); });
        MusicButton.onClick.AddListener(delegate { turnOnTrailShop(); }); //actually the trail shop
        MoneyButton.onClick.AddListener(delegate { turnOnValuablesShop(); });

    }
    void turnOnValuablesShop()
    {
        ColorsButton.GetComponent<Image>().color = Color.white;
        ShapesButton.GetComponent<Image>().color = Color.white;
        PathColorsButton.GetComponent<Image>().color = Color.white;
        ThemesButton.GetComponent<Image>().color = Color.white;
        MusicButton.GetComponent<Image>().color = Color.white;
        MoneyButton.GetComponent<Image>().color = Color.gray;

        PlayerColorText.GetComponent<Text>().color = Color.black;
        PlayerShapeText.GetComponent<Text>().color = Color.black;
        PathColorText.GetComponent<Text>().color = Color.black;
        ThemeText.GetComponent<Text>().color = Color.black;
        MusicText.GetComponent<Text>().color = Color.black;
        MoneyText.GetComponent<Text>().color = Color.white;

        PlayerColorShop.SetActive(false);
        PlayerShapeShop.SetActive(false);
        PathColorShop.SetActive(false);
        ThemeShop.SetActive(false);
        TrailShop.SetActive(false);
        ValuablesShop.SetActive(true);
    }

    void turnOnTrailShop()
    {
        ColorsButton.GetComponent<Image>().color = Color.white;
        ShapesButton.GetComponent<Image>().color = Color.white;
        PathColorsButton.GetComponent<Image>().color = Color.white;
        ThemesButton.GetComponent<Image>().color = Color.white;
        MusicButton.GetComponent<Image>().color = Color.gray;
        MoneyButton.GetComponent<Image>().color = Color.green;

        PlayerColorText.GetComponent<Text>().color = Color.black;
        PlayerShapeText.GetComponent<Text>().color = Color.black;
        PathColorText.GetComponent<Text>().color = Color.black;
        ThemeText.GetComponent<Text>().color = Color.black;
        MusicText.GetComponent<Text>().color = Color.white;
        MoneyText.GetComponent<Text>().color = Color.white;


        PlayerColorShop.SetActive(false);
        PlayerShapeShop.SetActive(false);
        PathColorShop.SetActive(false);
        ThemeShop.SetActive(false);
        TrailShop.SetActive(true);
        ValuablesShop.SetActive(false);


        //for default
        if (PlayerPrefs.GetInt("TrailOnce") == 0)
        {
            buyTrailItem(0, "RedTrail");
            PlayerPrefs.SetInt("TrailOnce", 1);
        }

        //if bought then keep transparent colors default if bought
        if (PlayerPrefs.GetInt("RedTrail", 0) == 1)
            GameObject.Find("RedTrailCost").GetComponent<Text>().text = "Red";
        if (PlayerPrefs.GetInt("BlackTrail", 0) == 1)
            GameObject.Find("BlackTrailCost").GetComponent<Text>().text = "Black";
        if (PlayerPrefs.GetInt("BlueTrail", 0) == 1)
            GameObject.Find("BlueTrailCost").GetComponent<Text>().text = "Blue";
        if (PlayerPrefs.GetInt("YellowTrail", 0) == 1)
            GameObject.Find("YellowTrailCost").GetComponent<Text>().text = "Yellow";
        if (PlayerPrefs.GetInt("OrangeTrail", 0) == 1)
            GameObject.Find("OrangeTrailCost").GetComponent<Text>().text = "Orange";
        if (PlayerPrefs.GetInt("GreenTrail", 0) == 1)
            GameObject.Find("GreenTrailCost").GetComponent<Text>().text = "Green";
        if (PlayerPrefs.GetInt("PurpleTrail", 0) == 1)
            GameObject.Find("PurpleTrailCost").GetComponent<Text>().text = "Purple";
        if (PlayerPrefs.GetInt("PinkTrailColor", 0) == 1)
            GameObject.Find("PinkTrailCost").GetComponent<Text>().text = "Pink";

        GameObject.Find(PlayerPrefs.GetString("WhichTrailSelected") + "Cost").GetComponent<Text>().text = "Selected"; //selected on start

    }


    void turnOnThemeShop()
    {
        ColorsButton.GetComponent<Image>().color = Color.white;
        ShapesButton.GetComponent<Image>().color = Color.white;
        PathColorsButton.GetComponent<Image>().color = Color.white;
        ThemesButton.GetComponent<Image>().color = Color.gray;
        MusicButton.GetComponent<Image>().color = Color.white;
        MoneyButton.GetComponent<Image>().color = Color.green;

        PlayerColorText.GetComponent<Text>().color = Color.black;
        PlayerShapeText.GetComponent<Text>().color = Color.black;
        PathColorText.GetComponent<Text>().color = Color.black;
        ThemeText.GetComponent<Text>().color = Color.white;
        MusicText.GetComponent<Text>().color = Color.black;
        MoneyText.GetComponent<Text>().color = Color.white;


        PlayerColorShop.SetActive(false);
        PlayerShapeShop.SetActive(false);
        PathColorShop.SetActive(false);
        ThemeShop.SetActive(true);
        TrailShop.SetActive(false);
        ValuablesShop.SetActive(false);



        //for default
        if (PlayerPrefs.GetInt("ThemeOnce") == 0)
        {
            buyThemeItem(0, "WhiteBlackColor");
            PlayerPrefs.SetInt("ThemeOnce", 1);
        }

        //if bought then keep transparent colors default if bought
        if (PlayerPrefs.GetInt("WhiteBlackColor", 0) == 1)
            GameObject.Find("WhiteBlackColorCost").GetComponent<Text>().text = "Normal";
        if (PlayerPrefs.GetInt("BlackWhiteColor", 0) == 1)
            GameObject.Find("BlackWhiteColorCost").GetComponent<Text>().text = "Inverted";
        if (PlayerPrefs.GetInt("BlueYellowColor", 0) == 1)
            GameObject.Find("BlueYellowColorCost").GetComponent<Text>().text = "Yankee";
        if (PlayerPrefs.GetInt("GreenRedColor", 0) == 1)
            GameObject.Find("GreenRedColorCost").GetComponent<Text>().text = "Holidays";
        if (PlayerPrefs.GetInt("PinkPurpleColor", 0) == 1)
            GameObject.Find("PinkPurpleColorCost").GetComponent<Text>().text = "Pink";
        if (PlayerPrefs.GetInt("GreenGreenColor", 0) == 1)
            GameObject.Find("GreenGreenColorCost").GetComponent<Text>().text = "Forest";
        if (PlayerPrefs.GetInt("YellowYellowColor", 0) == 1)
            GameObject.Find("YellowYellowColorCost").GetComponent<Text>().text = "Sandy";
        if (PlayerPrefs.GetInt("OrangeRedColor", 0) == 1)
            GameObject.Find("OrangeRedColorCost").GetComponent<Text>().text = "Sunny";

        GameObject.Find(PlayerPrefs.GetString("WhichThemeSelected") + "Cost").GetComponent<Text>().text = "Selected"; //selected on start
    }

    void turnOnPlayerColorShop()
    {
        ColorsButton.GetComponent<Image>().color = Color.gray;
        ShapesButton.GetComponent<Image>().color = Color.white;
        PathColorsButton.GetComponent<Image>().color = Color.white;
        ThemesButton.GetComponent<Image>().color = Color.white;
        MusicButton.GetComponent<Image>().color = Color.white;
        MoneyButton.GetComponent<Image>().color = Color.green;

        PlayerColorText.GetComponent<Text>().color = Color.white;
        PlayerShapeText.GetComponent<Text>().color = Color.black;
        PathColorText.GetComponent<Text>().color = Color.black;
        ThemeText.GetComponent<Text>().color = Color.black;
        MusicText.GetComponent<Text>().color = Color.black;
        MoneyText.GetComponent<Text>().color = Color.white;


        PlayerColorShop.SetActive(true);
        PlayerShapeShop.SetActive(false);
        PathColorShop.SetActive(false);
        ThemeShop.SetActive(false);
        ValuablesShop.SetActive(false);
        TrailShop.SetActive(false);




        //for default
        if (PlayerPrefs.GetInt("PlayerColorOnce") == 0)
        {
            BuyColorItem(0, "White");
            PlayerPrefs.SetInt("PlayerColorOnce", 1);
        }

        //if bought then keep transparent colors default if bought
        if (PlayerPrefs.GetInt("Red", 0) == 1)
            GameObject.Find("RedCost").GetComponent<Text>().text = "Red";
        if (PlayerPrefs.GetInt("Blue", 0) == 1)
            GameObject.Find("BlueCost").GetComponent<Text>().text = "Blue";
        if (PlayerPrefs.GetInt("Yellow", 0) == 1)
            GameObject.Find("YellowCost").GetComponent<Text>().text = "Yellow";
        if (PlayerPrefs.GetInt("Orange", 0) == 1)
            GameObject.Find("OrangeCost").GetComponent<Text>().text = "Orange";
        if (PlayerPrefs.GetInt("Green", 0) == 1)
            GameObject.Find("GreenCost").GetComponent<Text>().text = "Green";
        if (PlayerPrefs.GetInt("Purple", 0) == 1)
            GameObject.Find("PurpleCost").GetComponent<Text>().text = "Purple";
        if (PlayerPrefs.GetInt("Pink", 0) == 1)
            GameObject.Find("PinkCost").GetComponent<Text>().text = "Pink";
        if (PlayerPrefs.GetInt("Gold", 0) == 1)
            GameObject.Find("GoldCost").GetComponent<Text>().text = "Gold";
        if (PlayerPrefs.GetInt("White", 0) == 1)
            GameObject.Find("WhiteCost").GetComponent<Text>().text = "White";

        GameObject.Find(PlayerPrefs.GetString("WhichPlayerColorSelected") + "Cost").GetComponent<Text>().text = "Selected"; //selected on start
    }

    void turnOnPlayerShapeShop()
    {
        ColorsButton.GetComponent<Image>().color = Color.white;
        ShapesButton.GetComponent<Image>().color = Color.gray;
        PathColorsButton.GetComponent<Image>().color = Color.white;
        ThemesButton.GetComponent<Image>().color = Color.white;
        MusicButton.GetComponent<Image>().color = Color.white;
        MoneyButton.GetComponent<Image>().color = Color.green;

        PlayerColorText.GetComponent<Text>().color = Color.black;
        PlayerShapeText.GetComponent<Text>().color = Color.white;
        PathColorText.GetComponent<Text>().color = Color.black;
        ThemeText.GetComponent<Text>().color = Color.black;
        MusicText.GetComponent<Text>().color = Color.black;
        MoneyText.GetComponent<Text>().color = Color.white;


        PlayerColorShop.SetActive(false);
        PlayerShapeShop.SetActive(true);
        PathColorShop.SetActive(false);
        ThemeShop.SetActive(false);
        TrailShop.SetActive(false);
        ValuablesShop.SetActive(false);




        if (PlayerPrefs.GetInt("PlayerShapeOnce") == 0)
        {
            buyPlayerShapeItem(0, "Cube");
            PlayerPrefs.SetInt("PlayerShapeOnce", 1);
        }
        
        if (PlayerPrefs.GetInt("CubeShape", 0) == 1)
            GameObject.Find("CubeCost").GetComponent<Text>().text = "Cube";
        if (PlayerPrefs.GetInt("SphereShape", 0) == 1)
            GameObject.Find("SphereCost").GetComponent<Text>().text = "Sphere";
        if (PlayerPrefs.GetInt("BirdShape", 0) == 1)
            GameObject.Find("BirdCost").GetComponent<Text>().text = "Bird";
        if (PlayerPrefs.GetInt("TurtleShape", 0) == 1)
            GameObject.Find("TurtleCost").GetComponent<Text>().text = "Turtle";
        if (PlayerPrefs.GetInt("PlaneShape", 0) == 1)
            GameObject.Find("PlaneCost").GetComponent<Text>().text = "Fish";
        if (PlayerPrefs.GetInt("XShape", 0) == 1)
            GameObject.Find("XCost").GetComponent<Text>().text = "Butterfly";
        if (PlayerPrefs.GetInt("HeadShape", 0) == 1)
            GameObject.Find("HeadCost").GetComponent<Text>().text = "Squirrel";
        if (PlayerPrefs.GetInt("BatmanShape", 0) == 1)
            GameObject.Find("BatmanCost").GetComponent<Text>().text = "Cylinder";

        GameObject.Find(PlayerPrefs.GetString("WhichPlayerShapeSelected") + "Cost").GetComponent<Text>().text = "Selected"; //selected on start


    }

    void turnOnPathColorShop()
    {
        ColorsButton.GetComponent<Image>().color = Color.white;
        ShapesButton.GetComponent<Image>().color = Color.white;
        PathColorsButton.GetComponent<Image>().color = Color.gray;
        ThemesButton.GetComponent<Image>().color = Color.white;
        MusicButton.GetComponent<Image>().color = Color.white;
        MoneyButton.GetComponent<Image>().color = Color.green;

        PlayerColorText.GetComponent<Text>().color = Color.black;
        PlayerShapeText.GetComponent<Text>().color = Color.black;
        PathColorText.GetComponent<Text>().color = Color.white;
        ThemeText.GetComponent<Text>().color = Color.black;
        MusicText.GetComponent<Text>().color = Color.black;
        MoneyText.GetComponent<Text>().color = Color.white;


        PlayerColorShop.SetActive(false);
        PlayerShapeShop.SetActive(false);
        PathColorShop.SetActive(true);
        ThemeShop.SetActive(false);
        TrailShop.SetActive(false);
        ValuablesShop.SetActive(false);



        //for default
        if (PlayerPrefs.GetInt("PathColorOnce") == 0)
        {
            buyPathColorItem(0, "RedPath");
            PlayerPrefs.SetInt("PathColorOnce", 1);
        }

        //if bought then keep transparent colors default if bought
        if (PlayerPrefs.GetInt("RedPath", 0) == 1)
            GameObject.Find("RedPathCost").GetComponent<Text>().text = "Red";
        if (PlayerPrefs.GetInt("BluePath", 0) == 1)
            GameObject.Find("BluePathCost").GetComponent<Text>().text = "Blue";
        if (PlayerPrefs.GetInt("YellowPath", 0) == 1)
            GameObject.Find("YellowPathCost").GetComponent<Text>().text = "Yellow";
        if (PlayerPrefs.GetInt("OrangePath", 0) == 1)
            GameObject.Find("OrangePathCost").GetComponent<Text>().text = "Orange";
        if (PlayerPrefs.GetInt("GreenPath", 0) == 1)
            GameObject.Find("GreenPathCost").GetComponent<Text>().text = "Green";
        if (PlayerPrefs.GetInt("PurplePath", 0) == 1)
            GameObject.Find("PurplePathCost").GetComponent<Text>().text = "Purple";
        if (PlayerPrefs.GetInt("PinkPath", 0) == 1)
            GameObject.Find("PinkPathCost").GetComponent<Text>().text = "Pink";
        if (PlayerPrefs.GetInt("WhitePath", 0) == 1)
            GameObject.Find("WhitePathCost").GetComponent<Text>().text = "White";

        GameObject.Find(PlayerPrefs.GetString("WhichPathColorSelected") + "Cost").GetComponent<Text>().text = "Selected"; //selected on start
    }

    void buyTrailItem(int count, string trail)
    {
        if (PlayerPrefs.GetInt(trail, 0) == 0)
        {
            if (PlayerPrefs.GetInt("CoinCount", 0) >= count)
            {
                if(trail!= "RedTrail")
                    moneySound.PlayOneShot(moneys);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) - count);
                coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
                PlayerPrefs.SetString("Trail", trail);
                PlayerPrefs.SetInt(trail, 1);
                //GameObject.Find("RedCost").GetComponent<Animator>().Play("RedCost");

            }
            else
            {
                cannot.Play("warning", -1, 0f);

            }
        }

        //selects it
        if (PlayerPrefs.GetInt(trail, 0) == 1)
        {
            if (PlayerPrefs.GetInt("RedTrail", 0) == 1)
                GameObject.Find("RedTrailCost").GetComponent<Text>().text = "Red";
            if (PlayerPrefs.GetInt("BlackTrail", 0) == 1)
                GameObject.Find("BlackTrailCost").GetComponent<Text>().text = "Black";
            if (PlayerPrefs.GetInt("BlueTrail", 0) == 1)
                GameObject.Find("BlueTrailCost").GetComponent<Text>().text = "Blue";
            if (PlayerPrefs.GetInt("YellowTrail", 0) == 1)
                GameObject.Find("YellowTrailCost").GetComponent<Text>().text = "Yellow";
            if (PlayerPrefs.GetInt("OrangeTrail", 0) == 1)
                GameObject.Find("OrangeTrailCost").GetComponent<Text>().text = "Orange";
            if (PlayerPrefs.GetInt("GreenTrail", 0) == 1)
                GameObject.Find("GreenTrailCost").GetComponent<Text>().text = "Green";
            if (PlayerPrefs.GetInt("PurpleTrail", 0) == 1)
                GameObject.Find("PurpleTrailCost").GetComponent<Text>().text = "Purple";
            if (PlayerPrefs.GetInt("PinkTrailColor", 0) == 1)
                GameObject.Find("PinkTrailCost").GetComponent<Text>().text = "Pink";

            PlayerPrefs.SetString("Trail", trail);
            GameObject.Find(trail + "Cost").GetComponent<Text>().text = "Selected";
            PlayerPrefs.SetString("WhichTrailSelected", trail);

        }

    }

    void buyThemeItem(int count, string theme)
    {
        if (PlayerPrefs.GetInt(theme, 0) == 0)
        {
            if (PlayerPrefs.GetInt("CoinCount", 0) >= count)
            {
                if (theme != "WhiteBlackColor")
                    moneySound.PlayOneShot(moneys);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) - count);
                coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
                PlayerPrefs.SetString("Theme", theme);
                PlayerPrefs.SetInt(theme, 1);
                //GameObject.Find("RedCost").GetComponent<Animator>().Play("RedCost");

            }
            else
            {
                cannot.Play("warning", -1, 0f);

            }
        }

        //selects it
        if (PlayerPrefs.GetInt(theme, 0) == 1)
        {
            if (PlayerPrefs.GetInt("WhiteBlackColor", 0) == 1)
                GameObject.Find("WhiteBlackColorCost").GetComponent<Text>().text = "Normal";
            if (PlayerPrefs.GetInt("BlackWhiteColor", 0) == 1)
                GameObject.Find("BlackWhiteColorCost").GetComponent<Text>().text = "Inverted";
            if (PlayerPrefs.GetInt("BlueYellowColor", 0) == 1)
                GameObject.Find("BlueYellowColorCost").GetComponent<Text>().text = "Yankee";
            if (PlayerPrefs.GetInt("GreenRedColor", 0) == 1)
                GameObject.Find("GreenRedColorCost").GetComponent<Text>().text = "Holidays";
            if (PlayerPrefs.GetInt("PinkPurpleColor", 0) == 1)
                GameObject.Find("PinkPurpleColorCost").GetComponent<Text>().text = "Pink";
            if (PlayerPrefs.GetInt("GreenGreenColor", 0) == 1)
                GameObject.Find("GreenGreenColorCost").GetComponent<Text>().text = "Forest";
            if (PlayerPrefs.GetInt("YellowYellowColor", 0) == 1)
                GameObject.Find("YellowYellowColorCost").GetComponent<Text>().text = "Sandy";
            if (PlayerPrefs.GetInt("OrangeRedColor", 0) == 1)
                GameObject.Find("OrangeRedColorCost").GetComponent<Text>().text = "Sunny";

            PlayerPrefs.SetString("Theme", theme);
            GameObject.Find(theme + "Cost").GetComponent<Text>().text = "Selected";
            PlayerPrefs.SetString("WhichThemeSelected", theme);

        }
    }

    void buyPathColorItem(int count, string color)
    {
        if (PlayerPrefs.GetInt(color, 0) == 0)
        {
            if (PlayerPrefs.GetInt("CoinCount", 0) >= count)
            {
                if (color != "RedPath") 
                    moneySound.PlayOneShot(moneys);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) - count);
                coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
                PlayerPrefs.SetString("PathColor", color);
                PlayerPrefs.SetInt(color, 1);
                //GameObject.Find("RedCost").GetComponent<Animator>().Play("RedCost");

            }
            else
            {
                cannot.Play("warning", -1, 0f);

            }
        }

        //selects it
        if (PlayerPrefs.GetInt(color, 0) == 1)
        {
            if (PlayerPrefs.GetInt("RedPath", 0) == 1)
                GameObject.Find("RedPathCost").GetComponent<Text>().text = "Red";
            if (PlayerPrefs.GetInt("BluePath", 0) == 1)
                GameObject.Find("BluePathCost").GetComponent<Text>().text = "Blue";
            if (PlayerPrefs.GetInt("YellowPath", 0) == 1)
                GameObject.Find("YellowPathCost").GetComponent<Text>().text = "Yellow";
            if (PlayerPrefs.GetInt("OrangePath", 0) == 1)
                GameObject.Find("OrangePathCost").GetComponent<Text>().text = "Orange";
            if (PlayerPrefs.GetInt("GreenPath", 0) == 1)
                GameObject.Find("GreenPathCost").GetComponent<Text>().text = "Green";
            if (PlayerPrefs.GetInt("PurplePath", 0) == 1)
                GameObject.Find("PurplePathCost").GetComponent<Text>().text = "Purple";
            if (PlayerPrefs.GetInt("PinkPath", 0) == 1)
                GameObject.Find("PinkPathCost").GetComponent<Text>().text = "Pink";
            if (PlayerPrefs.GetInt("WhitePath", 0) == 1)
                GameObject.Find("WhitePathCost").GetComponent<Text>().text = "White";

            PlayerPrefs.SetString("PathColor", color);
            GameObject.Find(color + "Cost").GetComponent<Text>().text = "Selected";
            PlayerPrefs.SetString("WhichPathColorSelected", color);

        }
    }

    void BuyColorItem(int count, string color)
    {
        if (PlayerPrefs.GetInt(color, 0) == 0)
        {
            if (PlayerPrefs.GetInt("CoinCount", 0) >= count)
            {
                if (color != "White")
                    moneySound.PlayOneShot(moneys);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) - count);
                coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
                PlayerPrefs.SetString("PlayerColor", color);
                PlayerPrefs.SetInt(color, 1);
                //GameObject.Find("RedCost").GetComponent<Animator>().Play("RedCost");

            }
            else
            {
                cannot.Play("warning", -1, 0f);

            }
        }

        //selects it
        if (PlayerPrefs.GetInt(color, 0) == 1)
        {
            if (PlayerPrefs.GetInt("Red", 0) == 1)
                GameObject.Find("RedCost").GetComponent<Text>().text = "Red";
            if (PlayerPrefs.GetInt("Blue", 0) == 1)
                GameObject.Find("BlueCost").GetComponent<Text>().text = "Blue";
            if (PlayerPrefs.GetInt("Yellow", 0) == 1)
                GameObject.Find("YellowCost").GetComponent<Text>().text = "Yellow";
            if (PlayerPrefs.GetInt("Orange", 0) == 1)
                GameObject.Find("OrangeCost").GetComponent<Text>().text = "Orange";
            if (PlayerPrefs.GetInt("Green", 0) == 1)
                GameObject.Find("GreenCost").GetComponent<Text>().text = "Green";
            if (PlayerPrefs.GetInt("Purple", 0) == 1)
                GameObject.Find("PurpleCost").GetComponent<Text>().text = "Purple";
            if (PlayerPrefs.GetInt("Pink", 0) == 1)
                GameObject.Find("PinkCost").GetComponent<Text>().text = "Pink";
            if (PlayerPrefs.GetInt("Gold", 0) == 1)
                GameObject.Find("GoldCost").GetComponent<Text>().text = "Gold";
            if (PlayerPrefs.GetInt("White", 0) == 1)
                GameObject.Find("WhiteCost").GetComponent<Text>().text = "White";

            PlayerPrefs.SetString("PlayerColor", color);
            GameObject.Find(color + "Cost").GetComponent<Text>().text = "Selected";
            PlayerPrefs.SetString("WhichPlayerColorSelected", color);

        }
    }

    void buyPlayerShapeItem(int count, string shape)
    {
        if (PlayerPrefs.GetInt(shape + "Shape", 0) == 0)
        {
            if (PlayerPrefs.GetInt("CoinCount", 0) >= count)
            {
                if (shape != "Cube")
                    moneySound.PlayOneShot(moneys);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) - count);
                coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
                PlayerPrefs.SetString("PlayerShape", shape + "Shape");
                PlayerPrefs.SetInt(shape + "Shape", 1);
                //GameObject.Find("RedCost").GetComponent<Animator>().Play("RedCost");

            }
            else
            {
                cannot.Play("warning", -1, 0f);

            }
        }

        //selects it
        if (PlayerPrefs.GetInt(shape + "Shape", 0) == 1)
        {

            if (PlayerPrefs.GetInt("CubeShape", 0) == 1)
                GameObject.Find("CubeCost").GetComponent<Text>().text = "Cube";
            if (PlayerPrefs.GetInt("SphereShape", 0) == 1)
                GameObject.Find("SphereCost").GetComponent<Text>().text = "Sphere";
            if (PlayerPrefs.GetInt("BirdShape", 0) == 1)
                GameObject.Find("BirdCost").GetComponent<Text>().text = "Bird";
            if (PlayerPrefs.GetInt("TurtleShape", 0) == 1)
                GameObject.Find("TurtleCost").GetComponent<Text>().text = "Turtle";
            if (PlayerPrefs.GetInt("PlaneShape", 0) == 1)
                GameObject.Find("PlaneCost").GetComponent<Text>().text = "Fish";
            if (PlayerPrefs.GetInt("XShape", 0) == 1)
                GameObject.Find("XCost").GetComponent<Text>().text = "Butterfly";
            if (PlayerPrefs.GetInt("HeadShape", 0) == 1)
                GameObject.Find("HeadCost").GetComponent<Text>().text = "Squirrel";
            if (PlayerPrefs.GetInt("BatmanShape", 0) == 1)
                GameObject.Find("BatmanCost").GetComponent<Text>().text = "Cylinder";

            PlayerPrefs.SetString("PlayerShape", shape + "Shape");
            GameObject.Find(shape + "Cost").GetComponent<Text>().text = "Selected";
            PlayerPrefs.SetString("WhichPlayerShapeSelected", shape);

        }


    }
}




