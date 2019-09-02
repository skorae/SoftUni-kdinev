import java.util.Scanner;

public class Diamond {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        int stars = 0;
        
        if (n % 2 == 0) {
            stars = 2;
        }else {
            stars = 1;
        }

        String firstAndlastRow = reapetsStr("-", (n -1)/2)
                + reapetsStr("*", stars)
                + reapetsStr("-",(n -1)/2);
        System.out.println(firstAndlastRow);


       
        System.out.println(firstAndlastRow);

    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}