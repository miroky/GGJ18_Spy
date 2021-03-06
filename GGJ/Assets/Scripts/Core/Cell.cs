﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public GameManager GM;
    
    private bool _Use;
    private bool _Calling;

    private Transform _luz;

    #region Funciones Unity

    void Start()
    {
        _Use = false;
        _Calling = false;
        
        if (this.tag == "Cell_R")
        {
            _luz = this.transform.GetChild(0);
            _luz.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (this.tag == "Cell_R")
        {
            if (_Calling == true)
            {
                // Encender Luz (Hijo)
                _luz.gameObject.SetActive(true);
            }
            else
            {
                // Apagar Luz (Hijo)
                _luz.gameObject.SetActive(false);
            }
        }
    }

    #endregion

    #region Getters y Setters

    public bool GetUse()
    {
        return _Use;
    }

    public void SetUse(bool use)
    {
        _Use = use;
    }

    #endregion

    public bool CallCable()
    {
        // Debug.Log("Me has dado, soy " + this.name);

        // Si la celda es Receptora...
        if(this.tag == "Cell_R")
        {
            if (GM.SetFirstCellArray(this))
            {
                _Use = true;
                return true;
            }
            Debug.Log("1R NO SE PUEDE PONER CABLE EN CELDA");

        }
        // Si no, la celda es Destino...
        else
        {
            if (GM.SetSecondCellArray(this))
            {
                _Use = true;
				return true;
            }
            Debug.Log("2R NO SE PUEDE PONER CABLE EN CELDA");

        }
        return false;
    }

    public bool CallSpecialCable()
    {
        // Debug.Log("Me has dado, soy " + this.name);
        Vector2 pos = this.transform.position;

        // Si la celda es Receptora...
        if (this.tag == "Cell_R")
        {
            if (GM.SetFirstSpecialCable(this))
            {
                _Use = true;
				return true;
            }
            Debug.Log("1E NO SE PUEDE PONER CABLE EN CELDA");

        }
        // Si no, la celda es Destino...
        else
        {
            if (GM.SetSecondSpecialCable(this))
            {
                _Use = true;
				return true;
            }
            Debug.Log("2E NO SE PUEDE PONER CABLE EN CELDA");

        }
        Debug.Log("NO SE PUEDE PONER CABLE EN CELDA");
        return false;
    }

    public void SetCalling(bool aux)
    {
        _Calling = aux;
    }

	public bool GetCalling(){
	
		return _Calling;
	}
}
