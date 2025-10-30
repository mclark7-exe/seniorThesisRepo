# Senior Thesis Repo: Silliam Shakespeare's Theatre Simulator
As a historic theatre's new owner and director, put on shows by running through a gauntlet of fast-paced microgames.

## Overall gameplay loop

* The player selects the ‘showtime’ button to start the show
* After a ‘3, 2, 1, GO’ countdown, the curtain opens, and a random microgame is started
* Individual microgames will be further described below and will require a variety of inputs, including the touchscreen, gyroscope, accelerometer, and microphone
    * Every time a certain microgame is repeated in a single run, the microgame becomes slightly harder. This could entail a stricter timer, added visual distractions, or more complicated instructions
* Short instructions, a timer, and an ‘audience reaction’ bar are shown on screen 
    * The audience reaction starts around halfway full and will continually empty over time
    * The bar will empty slowly at first, but will speed up as the game goes on
* The player attempts to follow the onscreen instructions
* The audience reaction bar rises if the player successfully follows the instructions or falls if they fail to do so before the timer reaches zero
* Curtains close to cover the screen and open to a new microgame
* The player continues to play microgames until the audience reaction bar empties completely
* If the player fills the audience reaction bar completely during the show, they will enter an ‘encore,’ shown by a flashy pop-up at the end of the bar
* If the player achieves an encore, the audience reaction bar will stop falling until the player fails a microgame
* A statistics screen shows:
    * A final audience reaction score, based on how many microgames were completed 
    * An excerpt from a critic's review of the show, randomly picked based on audience reaction score
* player taps the ‘curtain call’ button to return to the theatre

## Microgames

### Spotlight

* An actress is singing a solo and frantically dancing around the stage
* The player controls a spotlight by tilting their phone
* The player must try to keep the spotlight on the actress
   * The audience reaction bar will fill when the spotlight is on the actress and will start falling when the spotlight is not on the actress
* Every time this microgame repeats:
    * There will be added distractions in the form of actors and set dressings onstage
    * The actress will move around the stage slightly faster
      
### Open the Curtains

* The player controls a stagehand backstage using a pulley rope system to open the curtains
* The player must swipe down on the touchscreen repeatedly to pull the pulley rope
* Every time this microgame repeats:
    * The rope will move less with each swipe
 
### Memorize Your Line

* An actor backstage is studying the script
* A random line from a famous play will appear on the screen
* The player must quickly memorize the line for later

### Remember Your Line

* After the player encounters the "Memorize Your Line" microgame, they will encounter this microgame later in the run
* The previous memorized line will appear on the screen along with two variations of the line
* The player must choose the correct line out of the three
* Every time this pair of microgames repeats:
    * The player must memorize longer and more complex lines
    * The variations of the line will be more subtle
 
### Quiet On Set!

* Cast and crew members are sitting backstage and must stay quiet
* Any tap on the touchscreen, tilting of the phone, or sound detected from the microphone (past a certain threshold) will cause the audience reaction bar to drop

### Belt

* A singer is onstage, about to belt a showstopping final note
* A bar appears onscreen showing the volume detected by the microphone
* The player must sing, yell, or otherwise make noise to get the bar past a certain threshold
