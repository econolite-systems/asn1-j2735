namespace Econolite.Asn1J2735.J2735;

public enum LayerType {
    none, 
    mixedContent, // two or more of the below types
    generalMapData, 
    intersectionData, 
    curveData, 
    roadwaySectionData, 
    parkingAreaData, 
    sharedLaneData,
}