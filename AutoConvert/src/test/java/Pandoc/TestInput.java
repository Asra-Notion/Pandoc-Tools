package Pandoc;

import org.junit.*;

public class TestInput {
    @Test
    public void testInsideBounds() throws Exception {
        boolean check = Input.checkIfValueInsideBounds(5,0,10);
        Assert.assertEquals(true,check);
    }

    @Test
    public void testLowerEdgeIn() throws Exception {
        boolean check = Input.checkIfValueInsideBounds(0,0,10);
        Assert.assertEquals(true,check);
    }

    @Test
    public void testLowerEdgeOut() throws Exception {
        boolean check = Input.checkIfValueInsideBounds(0,1,10);
        Assert.assertEquals(false,check);
    }

    @Test
    public void testUpperEdgeIn() throws Exception {
        boolean check = Input.checkIfValueInsideBounds(10,0,10);
        Assert.assertEquals(true,check);
    }

    @Test
    public void testUpperEdgeOut() throws Exception {
        boolean check = Input.checkIfValueInsideBounds(11,0,10);
        Assert.assertEquals(false,check);
    }
}
