package Pandoc;

import Pandoc.Native.Operations;

public class Main {
    public static void main(String[] args){
        //TODO: Settings JSON or XML
        Display.displayWelcome();
        Display.checkPandocPresent();
        Operations.parseArguments(args);
        if (!Operations.allParametersAreSet())
        {
            Operations.displaySelections();
        }
        Operations.findFiles();
        Operations.convertFiles();
    }
}
