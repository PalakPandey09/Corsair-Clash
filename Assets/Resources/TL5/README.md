Prefab: EnemyGenerationSystem Documention

1. How to use:
    Drag it to your Scenes.

2. Preparation:
    a.  Ensure that the list "Enemy Ships" has at least one GameObject can be used to generate.
    b.  Ensure there is a empty GameObject with Tag "EnemyShipParent" in your Scene.

3. Members:
    a.  Variable Instance: Class EnemyGenerationSystem on Prefab is a Singleton Class, Instance is the entry where you can call the function in Class.
    b.  Variable EnemyShips: This is a List of GameObject, which is used to save GameObject that will be generated under the Ships Parent.
    c.  Variable enemyShipParent: This is a GameObject used to organize generated EnemyShips, all generated ships will be attached to this GameObject.
    d.  Method GenerateEnemyies(): This is the function that generate all GameObject in the List EnemyShips.