package Pandoc;

public class Main {
    public static void main(String[] args){
        Display.checkPandocPresent();
        Display.displayMenu();
        Input.getMenuSelection(1,3);
    }
}
