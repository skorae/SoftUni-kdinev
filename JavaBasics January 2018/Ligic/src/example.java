import java.util.Scanner;

public class example {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a = 5;

        //System.out.println(a > 10); // po golqmo
        //System.out.println(a < 10); // po malko
       // System.out.println(a !=20); //razli4no
        //System.out.println(a == 5);
        //System.out.println(a >= 5);
        //System.out.println(a <= 5);

        String name = "pesho";
        String name1 = scanner.nextLine();

        System.out.println(name.equals(name1));// sravneniq na stringove
        System.out.println(name == name1);
    }
}
