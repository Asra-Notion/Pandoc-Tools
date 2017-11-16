package Pandoc;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Input {
    private static Scanner sc = new Scanner(System.in);

    public static int getMenuSelection(int min, int max){
        while (true) {
            try {
                int selection = Integer.parseInt(sc.next());
                if (checkIfValueInsideBounds(selection,min,max))
                {
                    return selection;
                }
                throw new NumberFormatException();
            } catch (NumberFormatException e) {
                System.out.println("Value is not between " + min + " and " + max + ", try again.");
            }
        }
    }

    protected static boolean checkIfValueInsideBounds(int value, int min, int max){
        return (value >= min && value <= max);
    }

    public static String getOutputFolder() {
        while (true) {
            try {
                String path = sc.next();
                return path;
            } catch (Exception e)
            {
                System.out.println("Error, please try again.");
            }
        }
    }
}
