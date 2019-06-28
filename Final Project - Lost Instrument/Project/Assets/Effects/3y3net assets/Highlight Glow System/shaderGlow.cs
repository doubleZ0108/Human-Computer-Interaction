using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class shaderGlow : MonoBehaviour {

	public bool useNormal=false;
	public enum allowedModes {onMouseEnter, alwaysOn, userCallFunctions};
	public enum labelModes {onMouseEnter, whenGlowIsOn};
	public allowedModes glowMode;
	public bool flashing=false; //Object will flash glow
	[Range (0.5f,4.0f)]
	public float flashSpeed=1f; //Flash speed
	public bool noOcclusion=false; //Show glow when object is occluded
	public bool scaleGlow = true; //If object is very sharp (nor squared) this help to get better glow
	[Range (0.15f,3.0f)]
	public float glowIntensity=1f; //Glow intensity on screen of the object
	[Range (0.5f,2.0f)]
	public float glowOpacity=1f; //Glow opacity on screen of the object
	public Color glowColor = Color.red; //Glow color of the object

	public String labelToDisplay="LABEL";	//Text to show
	public labelModes labelMode;            //onMouseEnter or whenGlowIsOn
    public Color labelColor=Color.white;	//Text color
	public bool outlined=true;				//Set true for display outlined text
	public Color outlineColor=Color.black;	//Outline text color
	public Font textFont = null;			//Text font
	public int fontSize=12;					//Text size

	private float clipGlow=0.04f; //Min real allowed glow
	private float maxGlow=0.25f; //Max real allowed glow
	private float lastGlow=0f; //Last glow based on distance. Incrase or decrease glow based on distance to crete the constant glow effect
	private float lastOpacity=0f; //Last glow based on distance. Incrase or decrease glow based on distance to crete the constant glow effect
    private Color lastColor = Color.white;
	private float clipDistance=1.0f; //Min distance. Closer the glow does not decrease
	private float maxDistance=10f; //Max distance. Further the glow does not increase
	//private List<Shader> originalObjetsShader;
	private Shader highightShaderVisible = null;	//Shader used to glow object
	private Shader highightShaderHidden = null;	//Shader used to glow object
    private Shader highightShaderVisibleNormal = null;    //Shader used to glow object
    private Shader highightShaderHiddenNormal = null; //Shader used to glow object
    private bool highlighted=false;
	private float flashPosition=1f;
	private bool flashDirectionUp = true;
	private GUIStyle style;
	private bool showLabel=false;

	void Awake() {
		//Grab the glow shader
		highightShaderVisibleNormal = Shader.Find ("3y3net/GlowVisibleNormal");
		highightShaderHiddenNormal = Shader.Find ("3y3net/GlowHiddenNormal");
		highightShaderVisible = Shader.Find ("3y3net/GlowVisible");
		highightShaderHidden = Shader.Find ("3y3net/GlowHidden");
	}
    
    Mesh CreateMesh(int[] triangles, int index, Mesh mesh)
    {
        Mesh newMesh = new Mesh();
        newMesh.Clear();
        newMesh.vertices = mesh.vertices;
        newMesh.triangles = triangles;
        newMesh.uv = mesh.uv;
        newMesh.uv2 = mesh.uv2;
        newMesh.uv3 = mesh.uv3;
        newMesh.uv4 = mesh.uv4;
        newMesh.colors = mesh.colors;
        newMesh.subMeshCount = 1;
        newMesh.normals = mesh.normals;
        //AssetDatabase.CreateAsset(newMesh, "Assets/" + mesh.name + "_submesh[" + index + "].asset");
        return newMesh;
    }
    

    Mesh CreateMesh2(int[] triangles, int index, Mesh mesh)
    {
        Mesh newMesh = new Mesh();
        List<int> vertexIndices = new List<int>();
        List<Vector3> verts = new List<Vector3>();
        List<Color> colors = new List<Color>();
        List<Vector3> normals = new List<Vector3>();

        List<Vector2> uvs, uvs2, uvs3, uvs4;
        uvs = new List<Vector2>(); uvs2 = new List<Vector2>(); uvs3 = new List<Vector2>(); uvs4 = new List<Vector2>();
        List<int> tris = new List<int>();

        newMesh.Clear();
        int curVertIndex = 0;
        int newVertIndex;
        int curSubVertIndex = 0;
        for (int i = 0; i < triangles.Length; i++)
        {
            curVertIndex = triangles[i];

            if (!vertexIndices.Contains(curVertIndex))
            {
                newVertIndex = curSubVertIndex;
                vertexIndices.Add(curVertIndex);

                verts.Add(mesh.vertices[curVertIndex]);

                if (mesh.colors != null && mesh.colors.Length > curVertIndex)
                    colors.Add(mesh.colors[curVertIndex]);

                normals.Add(mesh.normals[curVertIndex]);

                if (mesh.uv != null && mesh.uv.Length > curVertIndex)
                    uvs.Add(mesh.uv[curVertIndex]);
                if (mesh.uv2 != null && mesh.uv2.Length > curVertIndex)
                    uvs2.Add(mesh.uv2[curVertIndex]);
                if (mesh.uv3 != null && mesh.uv3.Length > curVertIndex)
                    uvs3.Add(mesh.uv3[curVertIndex]);
                if (mesh.uv4 != null && mesh.uv4.Length > curVertIndex)
                    uvs4.Add(mesh.uv4[curVertIndex]);

                curSubVertIndex++;
            }
            else
            {
                newVertIndex = vertexIndices.IndexOf(curVertIndex);
            }

            tris.Add(newVertIndex);
        }

        newMesh.vertices = verts.ToArray();
        newMesh.triangles = tris.ToArray();
        if (uvs.Count > 0)
            newMesh.uv = uvs.ToArray();
        if (uvs2.Count > 0)
            newMesh.uv2 = uvs2.ToArray();
        if (uvs3.Count > 0)
            newMesh.uv3 = uvs3.ToArray();
        if (uvs4.Count > 0)
            newMesh.uv4 = uvs4.ToArray();
        if (colors.Count > 0)
            newMesh.colors = colors.ToArray();

        newMesh.Optimize();
        newMesh.RecalculateBounds();
        newMesh.RecalculateNormals();

        return newMesh;
        //AssetDatabase.CreateAsset(newMesh, "Assets/"+mesh.name+"_submesh["+index+"].asset");
    }

    void SplitInChilds(GameObject go)
    {
        MeshFilter mf = go.GetComponent<MeshFilter>();

        if (mf == null)
            return;//An skinned mesh...

        Mesh mesh = mf.sharedMesh;
        if (mesh.subMeshCount < 2)
            return; //Nothing to do

        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] subMeshTris = mesh.GetTriangles(i);
            GameObject child = new GameObject("Son_" + i);
            child.AddComponent<MeshFilter>();
            child.GetComponent<MeshFilter>().mesh = CreateMesh(subMeshTris, i, mesh);
            child.AddComponent<MeshRenderer>();
            child.GetComponent<MeshRenderer>().material = go.GetComponent<Renderer>().materials[i];
            child.transform.parent = go.transform;
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = new Vector3(1, 1, 1);
        }
        go.GetComponent<MeshRenderer>().materials = new Material[] { };
        go.GetComponent<MeshRenderer>().enabled = false;
        mf.mesh = null;
    }

    // Use this for initialization
    void Start() {

        Component[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer singleRenderer in renderers)
            SplitInChilds(singleRenderer.gameObject);
        lastColor=glowColor;
        style = new GUIStyle();
		style.normal.textColor = labelColor;  
		style.alignment = TextAnchor.UpperCenter ;
		style.wordWrap = true;
		style.fontSize = fontSize;
		if(textFont!=null)
			style.font=textFont;
		else
			style.font= (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
	}

    public void OtherPointerEnter()
    {
        OnMouseEnter();
    }

    void OnMouseEnter() {
		if (!labelToDisplay.Equals ("") && labelMode==labelModes.onMouseEnter)
			showLabel=true;
		if(highlighted)
			return;
		if(glowMode == allowedModes.onMouseEnter)
			lightOn ();
	}

    public void OtherPointerExit()
    {
        OnMouseExit();
    }

    void OnMouseExit() {
		if (labelMode==labelModes.onMouseEnter)
			showLabel=false;
		if (!highlighted)
			return;
		if(glowMode == allowedModes.onMouseEnter)
			lightOff ();
	}

	
	
	void OnGUI () {
		if (!showLabel || Camera.main==null)
			return;
		float x=0, y=0;
        if (labelMode == labelModes.onMouseEnter) {
            x = Event.current.mousePosition.x - 149;
            y = Event.current.mousePosition.y - 20;
        }
        else {
            if (GetComponent<Renderer>() != null) {
                Vector3 pos = Camera.main.WorldToScreenPoint(GetComponent<Renderer>().bounds.center);
                x = pos.x - 150;
                y = Screen.height - pos.y;
            }
            else
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                x = pos.x - 150;
                y = Screen.height - pos.y;
            }
		}
		if (outlined)
			DrawOutline (new Rect(x,y,300,60), labelToDisplay, style, outlineColor, labelColor);
		else
			GUI.Label ( new Rect(x,y,300,60), labelToDisplay, style);
	}

	Color scaleFactor (Bounds meshfilter) {
		//Vector3 size=meshfilter.mesh.bounds.size;
		//Vector3 scale=meshfilter.transform.localScale;
		//Vector3 sizeScale = new Vector3(size.x*scale.x, size.y*scale.y, size.y*scale.z);
		Vector3 sizeScale = meshfilter.size;
		float maxSize = (sizeScale.x>sizeScale.y)?sizeScale.x:sizeScale.y;
		maxSize = (maxSize>sizeScale.z)?maxSize:sizeScale.z;
		sizeScale.x=maxSize/sizeScale.x; sizeScale.y=maxSize/sizeScale.y; sizeScale.z=maxSize/sizeScale.z; 
		maxSize = (sizeScale.x>sizeScale.y)?sizeScale.x:sizeScale.y;
		maxSize = (maxSize>sizeScale.z)?maxSize:sizeScale.z;
		sizeScale/=maxSize; 
		return  new Color(sizeScale.x, sizeScale.y, sizeScale.z, 1f);

	}

    public void lightOn() {
		if (!labelToDisplay.Equals ("") && labelMode==labelModes.whenGlowIsOn)
			showLabel=true;

        Renderer[] renderers;
		renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer singleRenderer in renderers)
        {
            if (!singleRenderer.enabled)
                continue;
            Debug.Log("Renderer found");
            //Create material for object
            Material newMat;
            if (useNormal)
            {
                if (noOcclusion)
                    newMat = new Material(highightShaderVisibleNormal);
                else
                    newMat = new Material(highightShaderHiddenNormal);
            }
            else
            {
                if (noOcclusion)
                    newMat = new Material(highightShaderVisible);
                else
                    newMat = new Material(highightShaderHidden);
            }

            //Set glow color
            newMat.SetColor("_GlowColor", glowColor);

            //Try to use scale trick
            if (scaleGlow && !useNormal)
                newMat.SetColor("_ScaleTrick", scaleFactor(singleRenderer.bounds));
            else
                newMat.SetColor("_ScaleTrick", new Color(1f, 1f, 1f, 1f));

            List<Material> mats = new List<Material>(singleRenderer.sharedMaterials);
            mats.Add(newMat);
            singleRenderer.sharedMaterials = mats.ToArray();
		}

		highlighted = true;
	}

	public void lightOff() {
		if (labelMode==labelModes.whenGlowIsOn)
			showLabel=false;
		int i=0;
		Component[] renderers;
		renderers = GetComponentsInChildren<Renderer>();
		
		foreach (Renderer singleRenderer in renderers)
        {
            if (!singleRenderer.enabled)
                continue;
            List<Material> mats = new List<Material>(singleRenderer.sharedMaterials);
            mats.RemoveAt(mats.Count - 1);
            singleRenderer.sharedMaterials = mats.ToArray();
        }
        lastGlow = 0;
        highlighted = false;
	}

	// Update is called once per frame
	void Update () {
		if(glowMode == allowedModes.alwaysOn && !highlighted)
			lightOn();

		if(highlighted) {
			float distance = Vector3.Distance (gameObject.transform.position, Camera.main.transform.position);
			distance = Mathf.Clamp (distance, clipDistance, maxDistance);
			distance -= clipDistance;
			float glow = clipGlow+(distance * (maxGlow - clipGlow) / ((maxDistance) - (clipDistance)));
			
			if(flashing) {
				if(flashDirectionUp) {
					flashPosition+=flashSpeed*Time.deltaTime;
					if(flashPosition>2f) {
						flashDirectionUp=false;
						flashPosition=2.0f;
					}
				}
				else {
					flashPosition-=flashSpeed*Time.deltaTime;
					if(flashPosition<0.5f) {
						flashDirectionUp=true;
						flashPosition=0.5f;
					}
				}
				glow*=flashPosition;
			}
			else
				glow *=glowIntensity;
			
			if(useNormal) {
				glow=glowIntensity/(8f* Mathf.Sqrt(distance));
                if(flashing)
                    glow *= flashPosition;
            }

			if(glow!=lastGlow) {
				Component[] renderers = GetComponentsInChildren<Renderer>();
                foreach (Renderer singleRenderer in renderers)
                {
                    if (!singleRenderer.enabled)
                        continue;
                    singleRenderer.materials[singleRenderer.materials.Length - 1].SetFloat("_Outline", glow);
                }
				lastGlow=glow;
			}
			
			if(glowOpacity!=lastOpacity) {
				Component[] renderers;
				renderers = GetComponentsInChildren<Renderer>();
                foreach (Renderer singleRenderer in renderers)
                {
                    if (!singleRenderer.enabled)
                        continue;
                    singleRenderer.materials[singleRenderer.materials.Length - 1].SetFloat("_Opacity", glowOpacity);
                }
				lastOpacity=glowOpacity;
			}

            if(glowColor!=lastColor)
            {
                Component[] renderers;
                renderers = GetComponentsInChildren<Renderer>();
                foreach (Renderer singleRenderer in renderers)
                {
                    if (!singleRenderer.enabled)
                        continue;
                    singleRenderer.materials[singleRenderer.materials.Length - 1].SetColor("_GlowColor", glowColor);
                }
                lastColor=glowColor;
            }
		}
	}

    //draw text of a specified color, with a specified outline color
    void DrawOutline(Rect position, String text, GUIStyle theStyle, Color outColor, Color inColor)
    {
        var backupStyle = theStyle;
        theStyle.normal.textColor = outColor;
        position.x--;
        GUI.Label(position, text, style);
        position.x += 2;
        GUI.Label(position, text, style);
        position.x--;
        position.y--;
        GUI.Label(position, text, style);
        position.y += 2;
        GUI.Label(position, text, style);
        position.y--;
        theStyle.normal.textColor = inColor;
        GUI.Label(position, text, style);
        theStyle = backupStyle;
    }
}
