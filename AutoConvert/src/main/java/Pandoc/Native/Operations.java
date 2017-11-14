package Pandoc.Native;

import java.io.*;
import java.util.ArrayList;

public class Operations {
    public static boolean checkForPandoc() {
        try {
            String line;
            Process pandoc = new ProcessBuilder("pandoc", "-v").start();
            BufferedReader input = new BufferedReader(new InputStreamReader(pandoc.getInputStream()));
            while ((line = input.readLine()) != null) {
                System.out.println(line);
            }
            input.close();
            return true;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return false;
    }

    public static void findFiles(){
        ArrayList<File> files = new ArrayList<File>();
        listf(System.getProperty("user.dir"),files);
    }

    public static void listf(String directoryName, ArrayList<File> files) {
        File directory = new File(directoryName);

        // get all the files from a directory
        File[] fList = directory.listFiles();
        for (File file : fList) {
            if (file.isFile() && file.getName().endsWith(".docx")) {
                files.add(file);
            } else if (file.isDirectory()) {
                listf(file.getAbsolutePath(), files);
            }
        }
    }
}
