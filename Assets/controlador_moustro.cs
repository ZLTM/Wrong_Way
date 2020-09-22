using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class controlador_moustro : MonoBehaviour
{
    public int tiempo_activacion;
    public float distancia_grito;
    public float velocidad;
    public GameObject moustro;
    public GameObject target,escondite;
    public AudioSource autochoq;
    public bool activado;
    public int fuerza;
    
    Animator anim_mous;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        anim_mous= moustro.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  restescena() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public IEnumerator action1() {
        Debug.Log("comenzando");
        yield return new WaitForSeconds(tiempo_activacion);
        anim_mous.SetBool("caminando",true);
        while (Vector3.Distance(moustro.transform.position,target.transform.position)> distancia_grito)
        {
            if (activado==false)
            {
                break;
            }
            moustro.transform.LookAt(target.transform);
            moustro.transform.position = Vector3.Lerp(moustro.transform.position, target.transform.position, velocidad* Time.deltaTime);
                yield return null;
        }
        if (activado==true)
        {
            target.GetComponent<Rigidbody>().AddExplosionForce(fuerza, Vector3.one, 3000f, 3000, ForceMode.Force);
            Invoke("restescena", 3);
            autochoq.Play();
        }

        anim_mous.SetBool("caminando", false);
        Debug.Log("llego");
        
        anim_mous.SetTrigger("cabeza");
        yield return new WaitForSeconds(2);
        if (activado == false)
        {

            while (Vector3.Distance(moustro.transform.position, target.transform.position) > 1)
            {
                moustro.transform.LookAt(escondite.transform);
                moustro.transform.position = Vector3.Lerp(moustro.transform.position, escondite.transform.position, (velocidad / 3) * Time.deltaTime);
                yield return null;
            }
            StopCoroutine("action1");
        }
        yield return new WaitForSeconds(1);
        StartCoroutine("action1");
    }
   
}
