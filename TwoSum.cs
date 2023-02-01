public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] ans = new int[2];
        Dictionary<int, int> occur = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++) {
            if(occur.ContainsKey(target - nums[i])) {
                ans[0] = occur[target - nums[i]];
                ans[1] = i;
            } else if(!occur.ContainsKey(nums[i])) {
                occur.Add(nums[i], i);
            }
        }
        return ans;
    }
}