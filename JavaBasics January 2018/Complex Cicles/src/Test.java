import java.util.Scanner;

public class Test {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        while (n < 10){
            System.out.println("n = " + n);
            n++;
        }
        System.out.println(n);
//        String quit = scanner.nextLine();
//        int num = 1;
//        String quit;

        //for (int i = 1; i < n; i+=3) {
        //    System.out.println(i);
        //}
//        while (!"quit".equalsIgnoreCase(quit)) {
//            System.out.println(n);
//            quit = scanner.nextLine();
//
//        }
//
//        do {
//            quit = scanner.nextLine();
//            System.out.println(n);
//        } while (!"quit".equalsIgnoreCase(quit));
    }
}
