using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;

namespace Diablo_8_SQLite
{
    //Asmund was here.
    public class Asmund_Test_Scene : Scene
    {
        //List<GameObject> descriptionCollection = new List<GameObject>();
        MakeUISkillTree function = new MakeUISkillTree();
        ShowStatsUI showStatsUI = new ShowStatsUI();

        //int databaseStandin = 0;

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    base.Draw(spriteBatch);
        //}

        public override void Initialize()
        {
            base.Initialize();
            //AsmundTest();
            function.MakeSkillTree(this);
            showStatsUI.MakeUI(this);
        }

        //public override void OnSwitchAwayFromThisScene()
        //{
        //    base.OnSwitchAwayFromThisScene();
        //}

        //public override void OnSwitchToThisScene()
        //{
        //    base.OnSwitchToThisScene();
        //}

        //public override void Update()
        //{
        //    //UpdateDescription();
        //    base.Update();
        //}
        //private void AsmundTest()
        //{
        //    GameObject background = new GameObject();
        //    SpriteRenderer sp = new SpriteRenderer("TalentsBackground", OriginPositionEnum.MidLeft, 0, Color.White);
        //    background.AddComponent<SpriteRenderer>(sp);
        //    background.Transform.Position = new Vector2(0, 0);
        //    background.Transform.Scale = new Vector2(
        //    (GraphicsSetting.Instance.ScreenSize.X / 2) / sp.Sprite.Width,
        //    (GraphicsSetting.Instance.ScreenSize.Y / 1) / sp.Sprite.Height);

        //    Instantiate(background);

        //    //MakeSkill("Skill1",
        //    //    "Mortal Strike\n\nStrikes the enemy for \nadditional damage.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 8.5f));

        //    //MakeSkill("Skill2",
        //    //    "Thunder Slam\n\nDamages all nearby \nenemies and slows them\ndown.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 2.5f));

        //    //MakeSkill("Skill3",
        //    //    "Whirlwind\n\nDeals weapon damage to\nall nearby enemies.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 1.5f));

        //    //MakeSkill("Skill4",
        //    //    "Shield Wall\n\nIncreases block value \nby 100%.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.47f, GraphicsSetting.Instance.ScreenSize.Y / 4.1f));

        //    //MakeSkill("Skill5",
        //    //    "Trueshot\n\nIncrease accuracy \nby 15%.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.24f, GraphicsSetting.Instance.ScreenSize.Y / 8.5f));

        //    //MakeSkill("Skill6",
        //    //    "Frost Arrow\n\nArrows you fire deal \nbonus damage and \nslows the target.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.24f, GraphicsSetting.Instance.ScreenSize.Y / 3.5f));

        //    //MakeSkill("Skill7",
        //    //    "Piercing Strike\n\nArrows reduces the \ntargets armor.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.08f, GraphicsSetting.Instance.ScreenSize.Y / 2.35f));

        //    //MakeSkill("Skill8",
        //    //    "Multi-shot\n\nFires multiple arrows \nin one attack.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.24f, GraphicsSetting.Instance.ScreenSize.Y / 1.25f));

        //    //MakeSkill("Skill9",
        //    //    "Empower\n\nIncreases stats by 20%.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.08f, GraphicsSetting.Instance.ScreenSize.Y / 1.65f));

        //    //MakeSkill("Skill10",
        //    //    "Tornado\n\nSummons a violent \ntornado that moves \non it's own, damaging \nand slowing down \nenemies that stand \nclose to it.",
        //    //    new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.47f, GraphicsSetting.Instance.ScreenSize.Y / 1.25f));

        //    MouseSettings.Instance.IsMouseVisible(true);

        //}

        //private GameObject MakeSkill(string sprite, string description, Vector2 pos)
        //{
        //    //Creates skill rank number display
        //    GameObject mini = new GameObject();
        //    mini.AddComponent<SpriteRenderer>();
        //    mini.Transform.Scale = new Vector2(GraphicsSetting.Instance.ScreenScale.X * 20, GraphicsSetting.Instance.ScreenScale.Y * 20);
        //    mini.Transform.Position = pos;
        //    TextGUI textMini = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(0.4f, 0.4f), databaseStandin.ToString()); ;
        //    textMini.LayerDepth = 0.11f;
        //    mini.AddComponent<TextGUI>(textMini);
        //    Instantiate(mini);

        //    //Creates Button
        //    GameObject button = new GameObject();
        //    button.AddComponent<SpriteRenderer>();
        //    ButtonGUI btn = button.AddComponent<ButtonGUI>(new ButtonGUI(SpriteContainer.Instance.sprite[sprite], SpriteContainer.Instance.sprite[sprite], Color.White, Color.Green));
        //    btn.OnClick = () => { SelectSkill(textMini); };
        //    button.Transform.Scale = new Vector2(GraphicsSetting.Instance.ScreenScale.X, GraphicsSetting.Instance.ScreenScale.Y);
        //    button.Transform.Position = pos;
        //    Instantiate(button);


        //    //Creates background/overlay for skill rank number
        //    ImageGUI miniImage = new ImageGUI(mini.GetComponent<SpriteRenderer>(), false, false);
        //    mini.AddComponent<ImageGUI>(miniImage);
        //    miniImage.SpriteRenderer.LayerDepth = 0.1f;

        //    //Creates parent of description box
        //    GameObject descBox = new GameObject();
        //    descBox.Transform.Position = pos;
        //    descBox.MyParent = button;

        //    //Creates background/overlay for description box
        //    GameObject overlay = new GameObject();
        //    overlay.AddComponent<SpriteRenderer>();
        //    ImageGUI image = new ImageGUI(overlay.GetComponent<SpriteRenderer>(), false, false);
        //    overlay.AddComponent<ImageGUI>(image);
        //    overlay.Transform.Scale = new Vector2(200, 200);
        //    overlay.Transform.Position = pos + new Vector2(80, 0);
        //    overlay.MyParent = descBox;
        //    overlay.GetComponent<SpriteRenderer>().LayerDepth = 0.2f;
        //    Color color1 = new Color(Color.Gray, 0.8f);
        //    overlay.GetComponent<SpriteRenderer>().Color = color1;

        //    //Creates text inside the description box
        //    GameObject textBox = new GameObject();
        //    TextGUI text = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(0.4f, 0.4f), description);
        //    text.LayerDepth = 0.21f;
        //    textBox.Transform.Position = pos + new Vector2(80, 0);
        //    textBox.AddComponent<TextGUI>(text);
        //    textBox.MyParent = descBox;

        //    Instantiate(descBox);
        //    Instantiate(overlay);
        //    Instantiate(textBox);

        //    descriptionCollection.Add(descBox);

        //    return button;
        //}
        //private void UpdateDescription()
        //{
        //    foreach (GameObject item in descriptionCollection)
        //    {
        //        item.IsActive = item.MyParent.GetComponent<ButtonGUI>().MouseIsHovering;
        //    }
        //}
        //private void SelectSkill(TextGUI textGUI)
        //{
        //    int tmp = 0;
        //    tmp = Convert.ToInt32(textGUI.Text);
        //    tmp++;
        //    textGUI.Text = tmp.ToString();
        //}
    }
}
