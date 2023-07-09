using UnityEngine;

public class StatPlayer : MonoBehaviour {
    
    public GameObject Player;
    public Checkpoint cp;

    public EnemyAI[] AI;
    public LevelPlayer LP;
    public HealthBar healthBar;
    //public ManaBar manaBar;

    public int healthPlayer;
    public int currentHealth;

    /*public int manaPlayer;
    public int currentMana;*/

    public int damagePlayer;
    private bool alive=true;
    public Vector3 position;

    
    void Start(){
       GameObject Enemy =GameObject.Find("Enemy");
        for (int i = 0; i < Enemy.transform.childCount;i++){
            AI[i]=Enemy.gameObject.transform.GetChild(i).GetChild(0).GetComponent<EnemyAI>();
        }

        position=new Vector3(0,0,0);
        currentHealth=SetHealthPlayer();
        healthBar.SetHealth(currentHealth);
        
        //currentMana=SetManaPlayer();
        //manaBar.SetMana(currentMana);

    }

    public void die(){
        currentHealth=0;
        //currentMana=0;
        damagePlayer=0;
        alive=false;
        
        Player.SetActive(alive);
        transform.parent.GetComponent<TristaScriptMoveBasic>().enabled=false;
        transform.parent.GetChild (1).GetComponent<TristaCameraController>().enabled=false;
        Invoke("revive",4);

    }

    public void revive(){
        transform.parent.position=new Vector3(cp.pos.x,cp.pos.y,cp.pos.z);
        healthPlayer=LP.healthL;
        currentHealth=healthPlayer; 
        healthBar.SetHealth(healthPlayer);
        
        //manaPlayer=LP.manaL;
        //currentMana=manaPlayer;
        //manaBar.SetMana(manaPlayer);

        damagePlayer=LP.damageL;
        alive=true;
        Player.SetActive(alive);
        transform.parent.GetComponent<TristaScriptMoveBasic>().enabled=true;
        transform.parent.GetChild (1).GetComponent<TristaCameraController>().enabled=true;

    }

    public void takeDamage(int idAI){
        if(currentHealth >=0){
            currentHealth-=AI[idAI].damageEnemy;

            healthBar.SetCurrentHealth(currentHealth);
        }
    }

    public void hitEnemy(int idAI){
        if(AI[idAI].healthEnemy>0){
        AI[idAI].healthEnemy-=damagePlayer;
        }
        if(AI[idAI].healthEnemy<=0){ 
            GameObject idEnemy =GameObject.Find(AI[idAI].name);
            Destroy(idEnemy.transform.parent.gameObject);

            LP.experiencePoint+=AI[idAI].experiencePointDropByEnemy;

        }
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.collider.tag=="Projectile" && collision.collider.name=="spyteAcid1(Clone)"){
            takeDamage(0);     
            Destroy(GameObject.Find("spyteAcid1(Clone)"));
        }
        if(collision.collider.tag=="Projectile" && collision.collider.name=="spyteAcid2(Clone)"){
            takeDamage(1);     
            Destroy(GameObject.Find("spyteAcid2(Clone)") );
        }
    }

    private int SetHealthPlayer(){
        return healthPlayer;
    }

    // Update is called once per frame
    void Update(){
         if(currentHealth <= 0){
            die();
        }
    }

}