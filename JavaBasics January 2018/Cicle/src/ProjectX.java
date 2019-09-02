import java.util.Scanner;

public class ProjectX {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n /2; i++) {
            String firstHalf = reapetsStr(" ", i) + "x"
                    + reapetsStr(" ", (n -2) - (2 * i)) + "x"
                    + reapetsStr(" ", i);
            System.out.println(firstHalf);
        }

        String middle = reapetsStr(" ", n /2 ) + "x" +
                reapetsStr(" ", n /2);
        System.out.println(middle);

        for (int i = 0; i < n / 2 ; i++) {
            String secondHalf = reapetsStr(" ",((n/2 )- 1) - i)
                    + "x" + reapetsStr(" ", 1 + 2 *i)
                    + "x" + reapetsStr(" ",((n/2 )- 1) + i);
            System.out.println(secondHalf);
        }


    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
