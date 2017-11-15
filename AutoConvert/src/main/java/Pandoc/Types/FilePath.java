package Pandoc.Types;


public class FilePath {
    private String extension;
    private String filenameAndPath;

    public FilePath(String completePath, String type){
        int index = completePath.indexOf(type);
        filenameAndPath = completePath.substring(0,index);
        extension = completePath.substring(index);
    }

    public FilePath(FilePath tester) {
        this.extension = tester.extension;
        this.filenameAndPath = tester.filenameAndPath;
    }

    public String getExtension() {
        return extension;
    }

    public String getFilenameAndPath() {
        return filenameAndPath;
    }

    public void changeFileExtension(String newExtension){
        this.extension = newExtension;
    }

    public String provideCompletePath(){
        String tmp = filenameAndPath + extension;
        return tmp;
    }

    public void modifyFilePathRelative(String newFolder, String currentDirectory) {
        String filename = filenameAndPath.substring(currentDirectory.length()+1);
        if (!newFolder.endsWith("\\")) {
            newFolder += '\\';
        }
        filenameAndPath = newFolder + filename;
        //System.out.println("filename:" + filename);
        //System.out.println("cwd:" + currentDirectory);
        //System.out.println("result:" + filenameAndPath);
    }
}
