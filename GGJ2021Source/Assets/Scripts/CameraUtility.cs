using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraUtility
{
    public static Rect getCameraBounds(Camera camera){
        float aspect = camera.aspect;
        float halfsize = camera.orthographicSize;
        Vector2 center = new Vector2(camera.transform.position.x,camera.transform.position.y);
        Vector2 origin = new Vector2(center.x - halfsize*aspect,center.y-halfsize);
        return new Rect(origin.x,origin.y,halfsize * aspect*2,halfsize*2);
    }

    public static bool isInBounds(Camera camera,Vector3 pos){
        Vector2 pos2D = new Vector2(pos.x,pos.y);
        Rect bounds = getCameraBounds(camera);
        return bounds.Contains(pos2D);
    }

    public static void drawBounds(Camera camera){
        Rect bounds = getCameraBounds(camera);
        Vector3 corner1 = new Vector3(bounds.xMin,bounds.yMax,0);
        Vector3 corner2 = new Vector3(bounds.xMax,bounds.yMax,0);
        Vector3 corner3 = new Vector3(bounds.xMin,bounds.yMin,0);
        Vector3 corner4 = new Vector3(bounds.xMax,bounds.yMin,0);
        Debug.DrawLine(corner1,corner2,Color.red);
        Debug.DrawLine(corner2,corner4,Color.red);
        Debug.DrawLine(corner3,corner4,Color.red);
        Debug.DrawLine(corner1,corner3,Color.red);
    }
    
}
