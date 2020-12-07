using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzeStudios.Variables;

[CreateAssetMenu(fileName = "CustomerProfile", menuName = "Customer", order = 0)]
public class CustomerProfile : ScriptableObject {
    public new StringVariable name;
}
