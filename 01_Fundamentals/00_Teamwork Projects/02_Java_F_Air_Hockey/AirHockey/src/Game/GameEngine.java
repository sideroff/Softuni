package Game;

import Game.entities.Player;
import Game.entities.Puck;
import display.Display;
import Game.tasks.TaskManager;
import gfx.Assets;
import gfx.ColorSwitcher;
import gfx.SpriteSheet;
import states.*;

import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferStrategy;


public class GameEngine implements Runnable{
    private String title;
    private Display display;
    private BufferStrategy bs;
    private Graphics g;
    private Thread thread;
    private boolean isRunning;
	private SpriteSheet numbers;
    private SpriteSheet alphabet;
    private SpriteSheet victoryAnimation;
    private SpriteSheet victoryAnimation2;
	public static TaskManager tasks;
    public static boolean isPause;

    private VictoryState victoryScreen;
	private MenuState mainMenu;
	private GameState game;
    private PauseState pause;
    private SettingsState settingsMenu;

    public static Puck puck;
    public static ColorSwitcher color1;
    public static ColorSwitcher color2;
    public static Player player1;
    public static Player player2;
	public static StateManager State;
    private static boolean countDownNeeded;

	public GameEngine(String name) {
        this.title = name;
    }

    private void init() {
        Assets.init();
        this.display = new Display(this.title);

	    this.display.getCanvas().addKeyListener(new InputHandler());
	    this.display.getCanvas().addMouseListener(new MouseInputHandler());

	    State = new StateManager();
	    this.mainMenu = new MenuState();
        this.victoryScreen = new VictoryState();
        this.settingsMenu = new SettingsState();
        this.pause = new PauseState();
	    this.game = new GameState();
        tasks = new TaskManager();

        this.numbers = new SpriteSheet(Assets.numbers, 60, 60);
        this.alphabet = new SpriteSheet(Assets.alphabet, 30, 30);
        this.victoryAnimation = new SpriteSheet(Assets.victoryAnim, 500, 160);
        this.victoryAnimation2 = new SpriteSheet(Assets.victoryAnim2, 200, 200);

        color1 = new ColorSwitcher();
        color2 = new ColorSwitcher();
        color2.nextColor(color1.getColor());
        player1 = new Player("Player 1", 250, 325, 1);
        player2 = new Player("Player 2", 800, 325, 2);
        puck = new Puck();
    }

    private void tick() {
        if(!GameEngine.isCountDownNeeded() && State.getState() == StateManager.STATES.GAME) {
            player1.getMallet().tick();
		    player2.getMallet().tick();
            puck.tick();
        }

    }
    public static void resetPositions(){
        puck.reset();
        player1.getMallet().reset(1);
        player2.getMallet().reset(2);
    }

    private void render() {
	    this.bs = this.display.getCanvas().getBufferStrategy();

	    if(this.bs == null) {
		    this.display.getCanvas().createBufferStrategy(2);
		    return;
	    }
	    this.g = this.bs.getDrawGraphics();
        this.g.clearRect(0, 0, Display.WIDTH, Display.HEIGHT);

        //Start Drawing
	    this.g.drawImage(Assets.blackBG, 0,0, 1200, 800, null);

	    if(State.getState() == StateManager.STATES.GAME) {
		    this.game.render(this.g, player1, player2, puck, this.numbers, this.alphabet);
	    } else if(State.getState() == StateManager.STATES.MENU) {
		    this.mainMenu.render(this.g);
	    } else if(State.getState() == StateManager.STATES.VICTORY) {
            this.game.render(this.g, player1, player2, puck, this.numbers, this.alphabet);
            this.victoryScreen.render(this.g, this.victoryAnimation, this.victoryAnimation2);
        } else if(State.getState() == StateManager.STATES.PAUSE) {
            this.game.render(this.g, player1, player2, puck, this.numbers, this.alphabet);
            this.pause.render(this.g);
        } else if(State.getState() == StateManager.STATES.SETTINGS) {
            this.settingsMenu.render(g, color1, color2);
        }

        //Stop Drawing
        this.g.dispose();
        this.bs.show();
    }

	@Override
    public void run() {
        this.init();
        int fps = 60;
        double delta = 0;
        long timeNow;
        long lastTime = System.nanoTime();

        while(isRunning) {
            double timePerTick = 1_000_000_000.0 / fps;
            timeNow = System.nanoTime();
            delta += (timeNow - lastTime) / timePerTick;
            tasks.tick(timeNow - lastTime);
	        lastTime = timeNow;

            if(delta >= 1) {
                this.tick();
                this.render();
                delta--;
            }
        }

        this.stop();
    }

    public synchronized void start() {
        this.thread = new Thread(this);

        this.isRunning = true;
        this.thread.start();
    }

    public synchronized void stop() {
        try {
            this.isRunning = false;
            this.thread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    public static String getPlayerName(int player) {
        String playerName;
        JPanel dialog = new JPanel();
        JLabel InputLabel = new JLabel("Please enter player " + player + " name: ");
        JTextField textBoxInput = new JTextField("Player " + player, 10);
        dialog.add(InputLabel);
        dialog.add(textBoxInput);

        String[] options = {"OK"};
        do {
            JOptionPane.showOptionDialog(null, dialog, "Please enter player name", JOptionPane.DEFAULT_OPTION, JOptionPane.QUESTION_MESSAGE, null, options, options[0]);
            playerName = textBoxInput.getText();
        } while (playerName == null || playerName.equals("") || playerName.equals(" "));

        return playerName;
    }

    public static boolean isCountDownNeeded() {
        return countDownNeeded;
    }

    public static void setIsCountDownNeeded(boolean countDown) {
        countDownNeeded = countDown;
    }


}
