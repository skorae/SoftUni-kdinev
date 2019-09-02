import java.util.Scanner;

public class FitStringIn20Chars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        if (text.length() >= 20){
            System.out.println(text.substring(0,20));
        }else{
            for (int i = 0; i < 20; i++) {
                if (i >= text.length()){
                    System.out.print("*");
                    continue;
                }
                System.out.print(text.charAt(i));
            }
        }
    }
}
