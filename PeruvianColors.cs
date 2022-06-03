using UnityEditor;
using UnityEngine;

public class PeruvianColors : EditorWindow
{
    [MenuItem("Sergio/Peruvian Colors")]
    public static void ShowWindow() => GetWindow<PeruvianColors>("Peruvian Colors");

    private Color _marColor = Color.blue;
    private Color _costaColor = Color.yellow;
    private Color _yungaColor = Color.white;
    private Color _quechuaColor = Color.white;
    private Color _suniColor = Color.white;
    private Color _punaColor = Color.white;
    private Color _jancaColor = Color.white;
    private Color _altaColor = Color.green;
    private Color _bajaColor = Color.green;

    private readonly Color _red = Color.red;
    private readonly Color _white = Color.white;

    private void OnGUI()
    {
        _marColor = EditorGUILayout.ColorField("Mar", _marColor);
        _costaColor = EditorGUILayout.ColorField("Costa o Chala", _costaColor);
        _yungaColor = EditorGUILayout.ColorField("Yunga", _yungaColor);
        _quechuaColor = EditorGUILayout.ColorField("Quechua", _quechuaColor);
        _suniColor = EditorGUILayout.ColorField("Suni o Jalca", _suniColor);
        _punaColor = EditorGUILayout.ColorField("Puna", _punaColor);
        _jancaColor = EditorGUILayout.ColorField("Janca", _jancaColor);
        _altaColor = EditorGUILayout.ColorField("Selva Alta o Rupa Rupa", _altaColor);
        _bajaColor = EditorGUILayout.ColorField("Selva Baja u Omagua", _bajaColor);

        if (GUILayout.Button("Pisos Altitudinales"))
        {
            Renderer[] renderers = FindObjectsOfType<Renderer>();

            Material marMaterial = Utils.CreateSpecularMaterial(_marColor);
            Material costaMaterial = Utils.CreateSpecularMaterial(_costaColor);
            Material yungaMaterial = Utils.CreateSpecularMaterial(_yungaColor);
            Material quechuaMaterial = Utils.CreateSpecularMaterial(_quechuaColor);
            Material suniMaterial = Utils.CreateSpecularMaterial(_suniColor);
            Material punaMaterial = Utils.CreateSpecularMaterial(_punaColor);
            Material jancaMaterial = Utils.CreateSpecularMaterial(_jancaColor);
            Material altaMaterial = Utils.CreateSpecularMaterial(_altaColor);
            Material bajaMaterial = Utils.CreateSpecularMaterial(_bajaColor);

            int length = renderers.Length;
            for (int i = 0; i < length; i++)
            {
                Renderer renderer = renderers[i];

                float posX = renderer.transform.position.x;
                if (renderer.transform.position.y > 5) renderer.material = punaMaterial;
                else if (posX < -6 || renderer.transform.position.y < -2) renderer.material = marMaterial;
                else if (posX < -5) renderer.material = costaMaterial;
                else if (posX < -3.75) renderer.material = yungaMaterial;
                else if (posX < -2.75) renderer.material = quechuaMaterial;
                else if (posX < 0.25) renderer.material = suniMaterial;
                else if (posX < 2) renderer.material = altaMaterial;
                else renderer.material = bajaMaterial;
            }
        }

        if (GUILayout.Button("Bandera"))
        {
            Renderer[] renderers = FindObjectsOfType<Renderer>();

            Material redMaterial = Utils.CreateSpecularMaterial(_red);
            Material whiteMaterial = Utils.CreateSpecularMaterial(_white);

            int length = renderers.Length;
            for (int i = 0; i < length; i++)
            {
                Renderer renderer = renderers[i];

                float posX = renderer.transform.position.x;
                if (posX > -3 && posX < 3) renderer.material = whiteMaterial;
                else renderer.material = redMaterial;
            }
        }
    }
}
